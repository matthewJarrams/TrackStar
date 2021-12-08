# TRACKSTAR

## System Requirements
> VisualStudio 2019 (referred to as "VS" from here on) </br>
> LiveCharts WPF and LiveCharts must be added as extensions in VS, instructions below

## Installation
1. Clone or download the code found within the GitHub repository </br>
1b. This can be done from within VS 2019, by cloning https://github.com/matthewJarrams/TrackStar </br>
1c. If the repository was downloaded as a ZIP file, extract all files
2. From the Solution Explorer within VS, open the provided solution, TrackStar.sln
3. Enable the graphing plugins, LiveCharts and LiveCharts.WPF </br>
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
6. Select "View Today's Workout", use as desired. Use "back" to return to homescreen once again
7. Navigate to the Meal Plan page (left-most in the bottom menu)
8. Select the "Ketogenic Diet", "View", then "Set Meal Plan". Use "back" and return to homescreen
9. Select "Log Nutrition". Use the checkboxes found at the bottom of the screen to update the graphs above. Use as desired, return to homescreen once done
10. Navigate to "Goals and Targets" (option to the left of the homescreen). View the graphs as desired, then use the "Add New" button found at the top of the page
11. Create a goal of your choosing, with a proper title and proper input values. Select "ok" once complete
12. Update this goal by selecting the "Update" button corresponding to the newly created goal. Change "New Record" input field to desired value and press "Update"
13. View the updated graph. Once done, navigate to the right-most menu, the user profile screen
14. Select the newly created goal as the graph to pin to the homescreen. Use the settings button (marked by the gear icon) and "Update Info" buttons as desired
15. Return to the homescreen to view the newly set graph

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
