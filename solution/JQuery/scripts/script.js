$(function(){

  //$("#hideMe").hide(1500);
  //$("#conteneur h1").hide(1500);
  //$("#conteneur p:last").hide(1500);
  //$("#conteneur p:not(.doNotHide)").hide(1500);
  //$("#conteneur a[href^=http]").hide(1500);
  //alert($("#conteneur a:first()").attr("href"));
  //$("#conteneur a:first()").attr("href", "http://google.fr");
  //alert($("#conteneur a:first()").attr("href"));
  //alert($("#conteneur a:first()").html());
  
  //$("#conteneur").click(test);
  
  //toggle : show if hide  and hide if show
  
  $("p:first()").animate({width:"10245px", opacity:0.2, height:"20px"}, 1000)
  
  $("#conteneur h1").click(
    function(){
      $(this).hide(2000);
    }
  );
  
})

function test(){
  alert("aa");
}
  