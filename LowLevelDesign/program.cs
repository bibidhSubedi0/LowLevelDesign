using LowLevelDesign.DesignPatterns.Behavioural.State;

var conn = new TCPConnection();

conn.Open();     // Closed → Listening
conn.Open();     // Listening → Established
conn.Send("Hello");
conn.Close();    // Established → Closed
