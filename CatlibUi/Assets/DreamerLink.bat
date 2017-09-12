cd /d %~dp0
set folder=%cd%\DreamerSource
set lib = c:\dreamer\lib
rmdir /s /q %folder%
mkdir %folder%

:: ----------------------------------------------------
:: link below
:: ----------------------------------------------------

:: 3rd
mklink /d %folder%\CatLib c:\dreamer\lib\3rd\CatLib\


:: Common
mklink /d %folder%\Utils c:\dreamer\lib\common\Utils\Utils\
mklink /d %folder%\MonoUtils c:\dreamer\lib\common\MonoUtils\

