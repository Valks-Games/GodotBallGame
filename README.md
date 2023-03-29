## I have given up on this. All contributions are welcome. If you contribute, I will answer any questions you may have and maybe even start working on this again.

https://user-images.githubusercontent.com/6277739/228397532-88651e52-94b3-4987-9335-156ba7fcae03.mp4  

## Issues
- Player does not move relative to camera
- Camera resets its rotation back to zero whenever you move the camera the next time
- Rotating too far past the clip value will force the player to rotate in the opposite direction to remove the gap value that was created. During this time the camera will feel stuck
- SpringArm3D teleports the camera. A fast lerp would be much better.
- Camera clips through player in certain scenarios.

## Todo (aside from the issues above)
- Prevent player from rotating the ball while the ball is suspended in the air (will require implementing Player.IsOnGround()
- Create a sexy level
