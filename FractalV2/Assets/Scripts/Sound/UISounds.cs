
// thanks for the tips: https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp

public class UISounds
{
    private UISounds(string value) { Value = value; }

    public string Value {  get; private set; }

    public static UISounds Click1 { get { return new UISounds("click1"); } }
    public static UISounds Click2 { get { return new UISounds("click2"); } }
    public static UISounds AlarmBell { get { return new UISounds("alarmbell"); } }
}
