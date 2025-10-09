using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.

If you don’t use the State pattern, your class might look like this:
void TCPConnection::Open() {
    if (state == CLOSED) {
        // open the connection
    } else if (state == ESTABLISHED) {
        // do nothing or error
    } else if (state == LISTENING) {
        // handle differently
    }
}

That means every method (like Open(), Close(), Send(string)), etc.) will have long if-else or switch statements depending on the state.
This makes the code:

Hard to read
Hard to modify
Hard to extend when adding new states


same kura applies for a text editor, if it is reader, editor, admin

for text docs we can
read, write, publish

void TextDoc::Write(){
    if (user == READER)
    {
        thow_error()
    }, ...
}

Instead of using if-else for each state, we:



 */
namespace LowLevelDesign.DesignPatterns.Behavioural.State
{
    // Interface defining common state operations
    public interface ITCPState
    {
        bool Open(TCPConnection connection);
        bool Close(TCPConnection connection);
        bool Send(TCPConnection connection, string msg);
        string Recv(TCPConnection connection);
    }

    // Context class
    public class TCPConnection
    {
        private ITCPState _state;

        public TCPConnection()
        {
            _state = new TCPClosed();  // default initial state
        }

        // Allow states to change the connection's current state
        public void ChangeState(ITCPState newState)
        {
            _state = newState;
            Console.WriteLine($"[STATE CHANGED] Now in: {_state.GetType().Name}");
        }

        // Delegate all behavior to current state
        public bool Open() => _state.Open(this);
        public bool Close() => _state.Close(this);
        public bool Send(string msg) => _state.Send(this, msg);
        public string Recv() => _state.Recv(this);
    }

    // Concrete States
    public class TCPClosed : ITCPState
    {
        public bool Open(TCPConnection connection)
        {
            Console.WriteLine("Opening connection...");
            connection.ChangeState(new TCPListening());
            return true;
        }

        public bool Close(TCPConnection connection)
        {
            throw new Exception("The connection is already closed");
        }

        public bool Send(TCPConnection connection, string msg)
        {
            throw new Exception("Cannot send, connection is closed");
        }

        public string Recv(TCPConnection connection)
        {
            throw new Exception("Cannot receive, connection is closed");
        }
    }

    public class TCPEstablished : ITCPState
    {
        public bool Open(TCPConnection connection)
        {
            throw new Exception("The connection is already established");
        }

        public bool Close(TCPConnection connection)
        {
            Console.WriteLine("Closing established connection...");
            connection.ChangeState(new TCPClosed());
            return true;
        }

        public bool Send(TCPConnection connection, string msg)
        {
            Console.WriteLine($"Sending message: {msg}");
            return true;
        }

        public string Recv(TCPConnection connection)
        {
            Console.WriteLine("Receiving data...");
            return "Received data";
        }
    }

    public class TCPListening : ITCPState
    {
        public bool Open(TCPConnection connection)
        {
            Console.WriteLine("Establishing connection...");
            connection.ChangeState(new TCPEstablished());
            return true;
        }

        public bool Close(TCPConnection connection)
        {
            Console.WriteLine("Closing listening connection...");
            connection.ChangeState(new TCPClosed());
            return true;
        }

        public bool Send(TCPConnection connection, string msg)
        {
            throw new Exception("Cannot send while listening");
        }

        public string Recv(TCPConnection connection)
        {
            Console.WriteLine("Listening for data...");
            return "Incoming request received";
        }
    }
}



/*

Naive Approach
class VideoPlayer
{
    private string _state = "Stopped";

    public void Play()
    {
        if (_state == "Stopped")
        {
            Console.WriteLine("Starting playback...");
            _state = "Playing";
        }
        else if (_state == "Paused")
        {
            Console.WriteLine("Resuming playback...");
            _state = "Playing";
        }
        else
        {
            Console.WriteLine("Already playing!");
        }
    }

    public void Pause()
    {
        if (_state == "Playing")
        {
            Console.WriteLine("Pausing...");
            _state = "Paused";
        }
        else
        {
            Console.WriteLine("Can't pause right now!");
        }
    }

    public void Stop()
    {
        if (_state != "Stopped")
        {
            Console.WriteLine("Stopping playback...");
            _state = "Stopped";
        }
        else
        {
            Console.WriteLine("Already stopped.");
        }
    }
}


               +----------------------+
               |      State           | <---- interface
               |----------------------|
               | + Play(): void       |
               | + Pause(): void      |
               | + Stop(): void       |
               +----------+-----------+
                          ▲
                          │
      +-------------------+-------------------+
      |                   |                   |
+-------------+    +--------------+     +---------------+
| PlayingState|    | PausedState  |     | StoppedState  |
|-------------|    |--------------|     |---------------|
| + Play()    |    | + Play()     |     | + Play()      |
| + Pause()   |    | + Pause()    |     | + Pause()     |
| + Stop()    |    | + Stop()     |     | + Stop()      |
+-------------+    +--------------+     +---------------+
                          │
                          │ uses
                          ▼
                 +----------------+
                 |  VideoPlayer   |  (Context)
                 |----------------|
                 | - state: State |
                 |----------------|
                 | + SetState(s)  |
                 | + Play()       |
                 | + Pause()      |
                 | + Stop()       |
                 +----------------+

using System;

// ----- State Interface -----
interface IPlayerState
{
    void Play(VideoPlayer player);
    void Pause(VideoPlayer player);
    void Stop(VideoPlayer player);
}

// ----- Concrete States -----
class PlayingState : IPlayerState
{
    public void Play(VideoPlayer player)
    {
        Console.WriteLine("Already playing!");
    }

    public void Pause(VideoPlayer player)
    {
        Console.WriteLine("Pausing playback...");
        player.SetState(new PausedState());
    }

    public void Stop(VideoPlayer player)
    {
        Console.WriteLine("Stopping playback...");
        player.SetState(new StoppedState());
    }
}

class PausedState : IPlayerState
{
    public void Play(VideoPlayer player)
    {
        Console.WriteLine("Resuming playback...");
        player.SetState(new PlayingState());
    }

    public void Pause(VideoPlayer player)
    {
        Console.WriteLine("Already paused.");
    }

    public void Stop(VideoPlayer player)
    {
        Console.WriteLine("Stopping from pause...");
        player.SetState(new StoppedState());
    }
}

class StoppedState : IPlayerState
{
    public void Play(VideoPlayer player)
    {
        Console.WriteLine("Starting playback...");
        player.SetState(new PlayingState());
    }

    public void Pause(VideoPlayer player)
    {
        Console.WriteLine("Can't pause. Not playing yet!");
    }

    public void Stop(VideoPlayer player)
    {
        Console.WriteLine("Already stopped.");
    }
}

// ----- Context -----
class VideoPlayer
{
    private IPlayerState _state;

    public VideoPlayer()
    {
        _state = new StoppedState(); // initial state
    }

    public void SetState(IPlayerState state)
    {
        _state = state;
    }

    public void Play() => _state.Play(this);
    public void Pause() => _state.Pause(this);
    public void Stop() => _state.Stop(this);
}

// ----- Demo -----
class Program
{
    static void Main()
    {
        var player = new VideoPlayer();

        player.Play();   // Start playing
        player.Pause();  // Pause
        player.Play();   // Resume
        player.Stop();   // Stop
        player.Pause();  // Invalid action
    }
}



*/