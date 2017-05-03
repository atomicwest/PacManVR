# PacManVR

### VR Game for Android and iOS

![PacGhost](/img/pacman_orange_cyan.PNG)

![PinkRed](/img/pink_red.PNG)

![PacManDead](/img/pacman_dead.PNG)

![PacManWon](/img/FinalScore.PNG)

Development in Unity/C#

#### [First Beta available](/Builds)
This build has some issues with the GoogleVR SDK; UI elements that were set as children to the Gvr object do not render for some reason.
I am working on forcing UI elements to appear through non-UI objects, such as the mini-map (which is an active feature in the first Beta).
The next Beta will (hopefully) have sound and a proper intro/restart option.

Basic features are completed:
* collecting pellets to score
* collecting super pellets to weaken and consume ghosts
* teleporting across the screen
* end game if out of lives or collected all pellets
* basic character animations (all ghosts currently have a generic wander script and do not actively find PacMan)
* UI timer and score
* ghosts chase PacMan or flee PacMan if super pellets are eaten 
* ghosts simulate the behavior in the original game; Red targets PacMan from behind, Pink targets PacMan from the front; Orange and Cyan are generally random
* (there is no strict queue-driven pathfinding algorithm yet, so there ghosts can run into a crowding problem at corners)
![Crowding1](/img/crowding_problem1.PNG)
![Crowding2](/img/crowding_problem2.PNG)

* in-game overhead map 
* Currently, a plane is set as a child object to the VR Camera but warps when the game is active ![minimap1](/img/minimap_temp_1.PNG)  ![minimap2](/img/minimap_temp_play.PNG)
* (GoogleVR plugin does not handle Render Textures applied to Unity UI image objects)
![DisplayMapBad](/img/overheadmap_notworking.PNG)


Next improvements on:
* levels
* ghost chasing, fixing crowding