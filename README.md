# PacManVR

### VR Game for Android and iOS

![PacGhost](/img/pacman_orange_cyan.PNG)

![PinkRed](/img/pink_red.PNG)

![PacManDead](/img/pacman_dead.PNG)

![PacManWon](/img/FinalScore.PNG)

Development in Unity/C#

#### [Betas available](/Builds)
The second beta has now been released and has sound enabled.

Basic features are completed:
* collecting pellets to score
* collecting super pellets to weaken and consume ghosts
* teleporting across the screen
* end game if out of lives or collected all pellets
* basic character animations 
* UI timer and score
* ghosts chase PacMan or flee PacMan if super pellets are eaten 
* ghosts simulate the behavior in the original game; Red targets PacMan from behind, Pink targets PacMan from the front; Orange and Cyan are one of the previous 2 behaviors
* (there is no strict queue-driven pathfinding algorithm yet, so ghosts can run into a crowding problem at corners)
![Crowding1](/img/crowding_problem1.PNG)
![Crowding2](/img/crowding_problem2.PNG)

* in-game overhead mini-map 
* Currently, a plane projects the render texture for the mini-map and is set as a child object to the VR Camera but warps with the VR lens when the game is active ![minimap1](/img/minimap_temp_1.PNG)  ![minimap2](/img/minimap_temp_play.PNG)
* (GoogleVR plugin does not handle Render Textures applied to Unity UI image objects)
![DisplayMapBad](/img/overheadmap_notworking.PNG)

* score and timer are now visible by making the UI text children of the Pac-Man mesh
* sound effects and cues have been added
* introduction sequence with Pac-Man start music clip added

Next improvements on:
* levels/ability to properly exit game
* ghost chasing, fixing crowding
* cleaning up code