# SimulatorGame
a game I want to play
## Unity Packages used
for this porject you your these packages form **unity** to work

- 3D Characters and Animation
- 3D World Building
- Input System

## Installation guide
### step 1: crate a unity project  
you can create a unity On unity hub and make a ``Universal 3D project`` from the templace that unity offers like below 
or u can just have a project with ``Universal pipeline`` package installed

![Universal 3D project select](https://github.com/SoupBoi1/private-public-image-readme/blob/main/Screenshot%202024-05-25%20at%209.41.20%20AM.png?raw=true)

### step 2: installing packages
 for this porject you your these packages form **unity** to work

- 3D Characters and Animation 
- 3D World Building
- Input System
when installed it should look somthing like this

![list of packages](https://github.com/SoupBoi1/private-public-image-readme/blob/main/Screenshot%202024-05-25%20at%209.49.00%20AM.png?raw=true)

when installing ``Input System`` package it may ask to restart **click yes**
--- image here
### step 3: install the project 
Go to folder of your unity project on your local machince 

**for example** I have saved my unity project name SimluatorGame which is localted `/SimluatorGame`

and if you don't know where you folder location is you can just use unity hub and click on the three dots clicking on open in folder (Windows)  or open in finder(Mac) which take you to the location of the folder liek below
--image

-then clone this repository inside of the project folder

`git clone https://github.com/SoupBoi1/SimulatorGame.git`

-then in the **folder of the project** rename folder `Assests` to  `Assests_old` so unity  

then u take your SimulatorGame floder which you jsut cloned and rename it to `Assests` so unity yours this repository as a Assest folder

# Step 4: Enjoy
open up unity everything should be working well be sure to open any of the secene file in play
> [!NOTE]
>those working on this project please create a new **branch** and work on it also **please** comment every function and class you care like seen in [Microsoft's Annex D Documentation comments]( https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments) so it easier for us to work with.
for example:

````

/// <summary>
/// Class <c>Point</c> models a point in a two-dimensional plane.
/// </summary>
public class Point
{
/// <summary>
/// Method <c>Draw</c> renders the point.
/// </summary>
void Draw() {...}
}. 
````