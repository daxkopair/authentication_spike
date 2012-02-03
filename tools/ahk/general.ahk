;==========================
;Initialise
;==========================
#NoEnv
SendMode Input
SetWorkingDir %A_ScriptDir% 
SetTitleMatchMode 2

autohotkey_spy = C:\utils\autohotkey\AU3_Spy.exe
process_explorer = C:\utils\sysinternals\procexp.exe
divvy = C:\utils\divvy\Divvy.exe
console = C:\utils\console\console.exe
camrec_exe = C:\utils\camtasia_studio\CamRecorder.exe
mingw = C:\utils\mingw\msys\1.0\msys.bat
camrec = Recording
camrec_preview = Preview
cygwin = cygwin
autohotkey_scripts = C:\users\jp\repositories\developwithpassion\devtools\windows\autohotkey\*.ahk

SysGet, screen_width, 59
SysGet, screen_height, 60 
screen_center_x := screen_width/2
screen_center_y := screen_height/2
right := screen_width

;===========================
actions="div,cm,as,e,kk,lm,clm,mmsc,mmc,mmn,wtr,wtl,wbl,wbr,wc,wf,rwind,ww,rr,sm,sr,se,sd,x,savr,ming,proc"
LWIN & y::
Input,command_input,T1/5,{enter}{esc}{tab},%actions%
if (ErrorLevel = Max | ErrorLevel = Timeout )
{
    return
}
if (command_input <> "")
{
  SetTimer, %command_input%, -1
}
return


;===================================================
;Basic Actions
;===================================================

;exit the current app
x:
send, !{F4}
return


;launch executor
e:
send, !q
return

;activate the menu in a shell window
cm:
click_mouse_in_active_window(14,16)
return

;launch the mingw shell
ming:
run_regular_program(mingw)
return

lm:
Click
return

clm:
ControlClick
return

;launch divvy
div:
run_regular_program(divvy)
return


;Move the mouse center
mmc:
move_mouse_to_middle_of_active_screen()
return


;Move the mouse center
mmsc:
click_mouse_in_middle_of_screen()
return

;Move the window to the next monitor
mmn:
send, +{Right}
return


;Run autohotkey spy
as:
run_regular_program(autohotkey_spy)
return

kk:
send, {Home}
return

wtl:
position_window_and_size(0,0,screen_center_x,screen_center_y)
return

wtr:
position_window_and_size(screen_center_x,0,screen_center_x,screen_center_y)
return

wbl:
position_window_and_size(0,screen_height-screen_center_y,screen_center_x,screen_center_y)
return

wbr:
position_window_and_size(screen_width - screen_center_x,screen_center_y,screen_center_x,screen_center_y)
return

wc:
WinGetActiveTitle, current_active_window
position_window_and_size(screen_center_x - screen_center_x/2,screen_center_y - screen_center_y/2,screen_width/2,screen_height/2)
return

wf:
position_window_and_size(0,0,screen_width,screen_height)
return

rwind:
run_regular_program(process_explorer)
SetTimer,CloseProcExplorer,500
return

;run process explorer
proc:
run_regular_program(process_explorer)
return

;close the current file window
ww:
send_keystrokes("!fc")
return

;Reload autohotkey scripts
rr:
Loop,%autohotkey_scripts%
{
  Run,%A_LoopFileFullPath%
}
return

;launch the start menu
sm:
send, {LWIN}
return



;========================================
;Camtasia
;========================================
;start new recording
sr:
IfWinNotExist, %camrec%
{
  run_regular_program(camrec_exe)
  wait_for_window(camrec)
}
send, {F9}
return


;stop recording
se:
send, {F10}
return

;save recording as
savr:
click_mouse_in_active_window(1223,866)
return

;delete current recording
dr:
click_mouse_in_active_window(1378,812)
return
;================================================

;shut down the machine
sd:
send_with_sleep("{LWin}",500)
send, {Right}{Enter}
return


CloseProcExplorer:
IfWinNotExist, Process Explorer
{
  process_explorer_close_attempts+=1
  if (process_explorer_close_attempts > 4)
  {
    process_explorer_close_attempts = 0
    disable_timer("CloseProcExplorer")
  }
}
else
{
  WinClose, Process Explorer
  disable_timer("CloseProcExplorer")
}
return
;================================================================
;utilities

wait_for_window(window_name)
{
  WinWaitActive, %window_name%,,0.8
  return ErrorLevel
}

disable_timer(timer_name)
{
  SetTimer, %timer_name%, off
}

move_mouse(x,y)
{
  MouseMove,x,y
}

move_mouse_to_middle_of_active_screen()
{
  WinGetPos,X,Y,Width,Height,A
  move_mouse(Width/2,Height/2)
}

click_mouse_in_middle_of_screen()
{
  SysGet, screen_width, 59
  SysGet, screen_height, 60 
  click_mouse_on_screen(screen_width/2,screen_height/2)
}

screen_drag(x1,y1,x2,y2)
{
  CoordMode,Mouse,Screen
  MouseClickDrag,Left,x1,y1,x2,y2
  CoordMode,Mouse,Relative
}

click_mouse_in_active_window(x,y)
{
  MouseMove,x,y
  MouseClick,Left
}

click_mouse_on_screen(x,y)
{
  CoordMode,Mouse,Screen
  click_mouse_in_active_window(x,y)
  CoordMode,Mouse,Relative
}

send_with_sleep(keystrokes,duration)
{
  send, %keystrokes%
  sleep,duration
}

send_keystrokes(keystrokes)
{
  send_with_sleep(keystrokes,0)
}

send_keystrokes_to_program(keystrokes,program)
{
  IfWinActive, %program%
  {
    send_keystrokes(keystrokes)
  }
}

run_start_menu_program(program)
{
  send_with_sleep("{LWIN}",100)
  send_with_sleep(program,100)
  send_with_sleep("{enter}",1000)
}

run_regular_program(program)
{
  Run, %program%
}

position_window_and_size(x1,y1,width,height)
{
  WinGetActiveTitle, current_active_window
  WinMove,%current_active_window%,,x1,y1,width,height
}


maximize_active_program()
{
  WinGetActiveTitle,current_active_window
  WinMaximize, %current_active_window%
}
