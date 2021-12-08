# TRACKSTAR

## System Requirements
> VisualStudio 2019 (referred to as "VS" from here on) </br>
> LiveCharts WPF and LiveCharts must be added as extensions in VS, instructions below

## Installation
1. Clone or download the code found within the GitHub repository </br>
1b. This can be done from within VS 2019, by cloning https://github.com/matthewJarrams/TrackStar </br>
1c. If the repository was downloaded as a ZIP file, extract all files
2. From the Solution Explorer within VS, open the provided solution, TrackStar.sln
3. Enable the graphing plugins, LiveCharts and LiveCharts.WP </br>
3b. Right-click on the project in VS, select "Manage NuGet Packages..." </br>
3c. Search for LiveCharts, install both LiveCharts and LiveChartsWPF </br>
3d. If any problems arise, please consult https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore-troubleshooting </br>
4. Run this solution, the main menu should now appear

If there are build errors when trying to run the solution, clean the solution by right-clicking on it and
selecting the "Clean" option, then "Build".

## Usage
1. Once on the main menu, select the "Click here to view available programs" button
2. Click the "Filter" button, selecting "Lose Weight", "Low", and "<= 30 days" as filters
3. From the newly filtered list, expand the "Cardio Training Program" and select "View"
4. Take a look at the information displayed on this page, cycling through days as well as other information
5. Use the "Set Program" button to set this as the active program. Use the "back" button and return to the home page
6. 

## Version History
*v1.0* <br/>
The initial horizontal prototype, very limited functionality and usage.
Heavy focus on visual implementation only. </br>
</br>
*v2.0* </br>
A final vertical prototype implementation.
The full list of changes can be viewed in the "Redesign Rationale" document.</br>


## Contributors
Richard Gingrich <br/>
Arne Hilao <br/>
Owen Hunter <br/>
Matt Jarrams <br/>
Zirui Li <br/>
