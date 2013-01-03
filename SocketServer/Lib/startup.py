import System.Console as Console

berror = lambda: Console.Beep(50, 300)
bwarn = lambda: Console.Beep(500, 300)
bok = lambda: Console.Beep(5000, 300)

binfos = False

def OnNewClient(event):
    Server.OnNewClient += event

def OnClosedClient(event):
    Server.OnClosedClient += event

def OnDataArrived(event):
    Server.OnDataArrived += event

@OnNewClient
def _OnNewClient(GSocketListener_Sender, GSocket_Client):
    if binfos: bok()

@OnClosedClient
def _OnClosedClient(GSocket_Client):
    if binfos: berror()

@OnDataArrived
def _OnDataArrived( GSocket_sender, bytearray_Data):
    if binfos: bok()

def PrintStartupHelp():
    print "binfos = True #For notifications"

def _ConnectionFormClosing(sender, e):
	pass

Server.FormClosing += _ConnectionFormClosing

#Server.speaker.SpeakAsync("Hello World")

say = Server.speaker.SpeakAsync

Server.ironTextBoxControl1.WriteText("PrintStartupHelp()\r\n")
Server.ironTextBoxControl1.SimEnter()
