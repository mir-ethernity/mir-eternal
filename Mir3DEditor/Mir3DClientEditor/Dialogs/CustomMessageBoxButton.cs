namespace Mir3DClientEditor.Dialogs
{
    public class CustomMessageBoxButton
    {
        public string Id { get; set; }
        public string Label { get; set; }

        public CustomMessageBoxButton(string id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}
