declare 
  -- Déclaration des variables.
  v_result               number;
  v_error_message        varchar2(255);
  v_error_count          number;
  
  -- Création de la procédure de tests.
  procedure ANALYZE_FUNCTION(
    p_package_name    in     varchar2,   -- Nom du package contenant la procédure à exécuter.
    p_function_name   in     varchar2,   -- Nom de la fonction à exécuter.
    p_params          in     varchar2,   -- Paramètres à passer à la fonction. 
    p_row_count       in     number,     -- Nombre d’enregistrements attendus.
    p_col_name        in     varchar2,   -- Nom de la colonne à tester.
    p_col_value       in     varchar2,   -- Valeur de la colonne attendu.
    p_debug           in     number,     -- Flag indiquant si l’on se trouve en mode debug.
    p_result             out number,     -- Flag indiquant si le test est ok.
    p_error_message      out varchar2    -- Message d’erreur en cas de problème rencontré lors du test.
  )
  is
    v_query                varchar2(500);
    v_data_type            user_arguments.data_type%type;
    v_cursor               sys_refcursor;
    v_cursor_id            number;
    v_cursor_nb_cols       integer;
    v_cursor_desc_tab      dbms_sql.desc_tab;
    v_cursor_date_value    date;
    v_cursor_text_value    varchar2(2000);
    v_cursor_number_value  number;
    v_text                 varchar2(4000);
    v_result_row_count     number;
    v_result_col_index     number;
    v_result_col_value     varchar2(255);
    v_start                number;
    v_stop                 number;
    
  begin
    -- Initialisation des variables.
    v_start         := DBMS_UTILITY.GET_TIME;
    p_result        := 1;
    p_error_message := '';
    
    -- Génération de la requête.
    v_query := 'select ' || p_package_name || '.' || p_function_name || '(' || p_params || ') from dual';
    dbms_output.put_line ('Fonction à tester : ' || p_package_name || '.' || p_function_name || '(' || p_params || ')');
    if(p_row_count is not null) then
      dbms_output.put_line ('  - Nombre d’enregistrements attendus : ' || p_row_count || '.');
    end if;
    if(p_col_name is not null) then
      dbms_output.put_line ('  - Valeur attendue pour la colonne ' || p_col_name || ' : ' || p_col_value || '.');
    end if;
    
   -- Récupération du type de retour.
   select data_type
     into v_data_type
     from user_arguments
    where package_name = p_package_name
      and object_name  = p_function_name 
      and in_out = 'OUT';
   
    if(v_data_type = 'VARCHAR2') then
      
      -- Éxécution de la procédure.
      execute immediate v_query into v_cursor_text_value;
      v_result_col_value := v_cursor_text_value;
      
      -- Affichage des valeurs.
      -- Contrôle de la valeur de la colonne à tester.
      -- Contrôle du nombre d’enregistrements.
      if(p_debug = 1 or p_col_name is not null) then
      
        -- Affichage du résultat.
        if(p_debug = 1) then
          dbms_output.put_line ('Affichage du résultat de la requête : ' || v_result_col_value);
        end if;
        
        -- Contrôle de la valeur de la colonne à tester.
        if(p_col_name is not null and p_col_value != v_result_col_value) then
          p_result := 0;
          p_error_message := p_error_message || chr(10)  || 'Le contrôle du résultat de la requête a échoué (attendu : `' || p_col_value || '`, trouvé : `' || v_result_col_value || '`).';
        end if;
      end if;
    elsif(v_data_type != 'REF CURSOR') then
      dbms_output.put_line ('LE TYPE ' || v_data_type || 'N’EST PAS GÉRÉ  !!');
    elsif(v_data_type = 'REF CURSOR') then
   
      -- Éxécution de la procédure.
      execute immediate v_query into v_cursor;
    
      -- Ouverture du curseur.
      v_cursor_id := dbms_sql.to_cursor_number(v_cursor);
     
      -- Récupération des colonnes du curseur.
      dbms_sql.describe_columns (v_cursor_id, v_cursor_nb_cols, v_cursor_desc_tab);
      for pos in 1 .. v_cursor_nb_cols
      loop
        case v_cursor_desc_tab (pos).col_type
          when 1 then 
           dbms_sql.define_column (v_cursor_id, pos, v_cursor_text_value, 2000);
          when 2 then 
            dbms_sql.define_column (v_cursor_id, pos, v_cursor_number_value);
          when 12 then 
            dbms_sql.define_column (v_cursor_id, pos, v_cursor_date_value);
          else 
            dbms_sql.define_column (v_cursor_id, pos, v_cursor_text_value, 2000);
        end case;
      end loop;
    
      -- Affichage des colonnes.
      -- Récupération de l’index de la colonne à tester.
      if(p_debug = 1 or p_col_name is not null) then
        v_text := '';
        v_result_col_index := 0;
        for pos in 1 .. v_cursor_nb_cols
        loop
          v_text := ltrim (v_text || ', ' || lower (v_cursor_desc_tab (pos).col_name), ', ');
          if(trim(lower(v_cursor_desc_tab (pos).col_name)) = trim(lower(p_col_name))) then
            v_result_col_index := pos;
          end if;
        end loop;
        -- Affichage des colonnes.
        if(p_debug = 1) then
          dbms_output.put_line ('Affichage des colonnes : ' || v_text);
          -- Affichage de l’index de la colonne à tester.
          if(p_col_name is not null) then
            dbms_output.put_line ('Index de la colonne à tester : ' || v_result_col_index);
          end if;
        end if;
      end if;
      
      -- Affichage des valeurs.
      -- Contrôle de la valeur de la colonne à tester.
      -- Contrôle du nombre d’enregistrements.
      if(p_debug = 1 or p_row_count is not null or p_col_name is not null) then
        v_result_row_count := 0;
        loop
          exit when dbms_sql.fetch_rows (v_cursor_id) = 0;
          v_result_row_count := v_result_row_count+1;
        
          if(p_debug = 1 or p_col_name is not null) then
            v_text := '';
            v_result_col_value := '';
            
            for pos in 1 .. v_cursor_nb_cols
            loop
              case v_cursor_desc_tab(pos).col_type
              when 1 then
                dbms_sql.column_value (v_cursor_id, pos, v_cursor_text_value);
                v_text := ltrim (v_text || ', "' || v_cursor_text_value || '"', ', ');
                if(p_col_name is not null and pos = v_result_col_index) then
                  v_result_col_value := v_cursor_text_value;
                end if;
              when 2 then
                dbms_sql.column_value (v_cursor_id, pos, v_cursor_number_value);
                v_text := ltrim (v_text || ', ' || v_cursor_number_value, ', ');
                if(p_col_name is not null and pos = v_result_col_index) then
                  v_result_col_value := v_cursor_number_value;
                end if;
              when 12 then
                dbms_sql.column_value (v_cursor_id, pos, v_cursor_date_value);
                v_text := ltrim (v_text || ', '|| to_char (v_cursor_date_value, 'dd/mm/yyyy hh24:mi:ss'),', ');
                if(p_col_name is not null and pos = v_result_col_index) then
                  v_result_col_value := to_char (v_cursor_date_value, 'dd/mm/yyyy');
                end if;
              else
                v_text := ltrim (v_text || ', "' || v_cursor_text_value || '"', ', ');
                if(p_col_name is not null and pos = v_result_col_index) then
                  v_result_col_value := v_cursor_text_value;
                end if;
              end case;
            end loop;
            
            -- Affichage des valeurs.
            if(p_debug = 1) then
              dbms_output.put_line ('Affichage des valeurs de l’enregistrement ' || v_result_row_count || ' : ' || v_text);
            end if;
            
            -- Contrôle de la valeur de la colonne à tester.
            if(p_col_name is not null and p_col_value != v_result_col_value) then
              p_result := 0;
              p_error_message := p_error_message || chr(10)  || '>>>>>>> Le contrôle de la valeur de la colonnne `' || p_col_name || '` a échoué (attendu : `' || p_col_value || '`, trouvé : `' || v_result_col_value || '`).';
            end if;
            
          end if;
        end loop;
        
        -- Contrôle du nombre d’enregistrements.
        if(p_row_count is not null and v_result_row_count != p_row_count) then
          p_result := 0;
          p_error_message := p_error_message || chr(10)  || '>>>>>>> Le contrôle sur le nombre d’enregistrements a échoué (attendu : ' || p_row_count || ', trouvé : ' || v_result_row_count || ').';
        end if;
        
      end if;
      
      -- Fermeture du curseur.
      dbms_sql.close_cursor (v_cursor_id);

    end if;
    
    v_stop := DBMS_UTILITY.GET_TIME;
    dbms_output.put_line ('  - Durée d’exécution  : ' || ((v_stop-v_start)*10) || ' ms.');
 end;
  
begin
  
  v_error_count := 0;
  
  for rq in (
      select distinct 'PKG___'                           as package_name,
             'GET__()'                                   as function_name,
             null                                        as params,
             count(*)                                    as row_count,
             0                                           as debug,
             null                                        as col_name,
             null                                        as col_value
        from MDL_JLN_DPL
    union
      select ddistinct 'PKG___'                           as package_name,
             'GET__()'                                   as function_name,
             to_char(ID)                                 as params,
             1                                           as row_count,
             0                                           as debug,
             'ID'                                        as col_name,
             to_char(ID)                                 as col_value
        from MDL_JLN_DPL
       group by MJD_ID

    )
    
  loop
    
    -- Exécution de la procédure.
    ANALYZE_FUNCTION(rq.package_name, rq.function_name, rq.params, rq.row_count, rq.col_name, rq.col_value, rq.debug, v_result, v_error_message);
    
    -- Analyse du résultat.
    if(v_result = 1) then
      dbms_output.put_line ('  - Résulat ok');  
    else
      dbms_output.put_line ('  - Résulat ko : ' || v_error_message);
      v_error_count := v_error_count+1;
    end if;
  
  end loop;
  
  if(v_error_count > 0) then
    dbms_output.put_line ('/!\ Il y a ' || v_error_count || ' test(s) en erreur /!\'); 
  end if;
  
end;
