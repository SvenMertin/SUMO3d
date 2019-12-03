:: Inspired by https://www.youtube.com/watch?v=_2KIKjGvBwU

@echo off
setlocal
cls
:: Set paths
Set workingDir=%CD%
Set sumoDir=%workingDir%\AdditionalExecutables\sumo-svn
Set sumoBin=%sumoDir%\bin
Set sumoTools=%sumoDir%\tools
Set osmFileunfiltered=%workingDir%\map.osm
Set osmFile=%workingDir%\map_filtered.osm
Set miniConda=%workingDir%\AdditionalExecutables\Miniconda2

:: Add to windows enviroment variables
Setx SUMO_HOME "%sumoDir%"
Set PATH=%miniConda%;%miniConda%\Scripts;%miniConda%\Library\bin

:: Ask for number of simulated vehicles
set /p vehicleCount="Enter number of vehicles to be simulated: "
set /p period="Enter period time of vehicle insertions in seconds: "
set /p binomial="Enter the binomial distribution for the insertion period: "
set /p fringeFactor="Enter the fringe factor: "

:: Delete previous output folder
cd %workingDir%
rd output /S /Q
mkdir output

python "%sumoTools%\randomtrips.py" -n map.net.xml -r map.rou.xml -e %vehicleCount% -l --binomial=%binomial% -p %period% --fringe-factor=%fringeFactor%

:: Move all files to the output folder (including the map.osm)
move map.rou.alt.xml ./output/map.rou.alt.xml
move map.rou.xml ./output/map.rou.xml
move trips.trips.xml ./output/trips.trips.xml
copy AdditionalFiles\map.sumo.cfg output\map.sumo.cfg
copy AdditionalFiles\additional.xml output\additional.xml
copy map.net.xml output\map.net.xml
copy map.poly.xml output\map.poly.xml

rename map.osm map_processed.osm

echo "%sumoBin%\sumo-gui.exe" -c map.sumo.cfg -a "additional.xml" --summary "summary.xml" >output/startSimulation.bat


