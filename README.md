Turn-Off-Screen-And-Mouse
=========================
Win Forms App that turns off the screen and the mouse.<br>
[Direct download](https://github.com/TsvetanKT/Turn-Off-Screen-And-Mouse/raw/master/TurnOffScreenAndMouse.exe)

### Description:
*	Turns off the screen.
*	Disables the mouse so mouse movements can't wake up the screen.
*	Press any keyboard key to restore the screen and the mouse.


### Requirements:
*	Windows XP and above.
*	.NET Framework 4 and above.

### Run:
*	The app is single `.exe ` file, no need for installation.
*	Put the file in some folder (different than on Desktop).
*	Create a shortcut on the Desktop.
*	In Windows **Device Manager** locate your mouse.
*	**Properities** → **Details** tab → Property: **Device Instance Path**
*	Copy the Value (something like: `HID\VID_093A&PID_2510\6&3147E919&0&0000`)
*	In the shortcut locate to Shortcut tab → Target
*	Paste the copied value after the exe. Example:<br>
`C:\Test\TurnOffScreenAndMouse.exe`<br>
becomes<br>
`C:\Test\TurnOffScreenAndMouse.exe HID\VID_093A&PID_2510\6&3147E919&0&0000`
*	(Optional) Change the icon.
*	(Optional) Add a Shortcut key (Hot key).