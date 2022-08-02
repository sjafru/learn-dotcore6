using Flunt.Notifications;

namespace Lib.Contacts.Domain;

public class Phone
{
    public enum PhoneType
    {
        Mobile = 1,
        Home
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Number { get; set; } = string.Empty;

    public PhoneType Type { get; set; }
}

public class Contact : Notifiable<Notification>
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string[] Emails { get; set; } = new String[6];

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public Phone[] Phones { get; set; } = new Phone[6];
}
