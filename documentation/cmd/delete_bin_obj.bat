@echo off

FOR /D /r %%n IN (*) DO (
  IF EXIST %%n\bin (
    echo %%n\bin
    rd /s /q %%n\bin
  )
  IF EXIST %%n\obj (
    echo %%n\obj
    rd /s /q %%n\obj
  )
)

pause