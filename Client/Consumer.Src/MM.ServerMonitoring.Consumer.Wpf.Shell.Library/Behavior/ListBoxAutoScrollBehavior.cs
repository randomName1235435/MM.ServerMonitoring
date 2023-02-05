using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Behavior;

public class ListBoxAutoScrollBehavior
{
    private static readonly Dictionary<ListBox, Capture> Associations = new();

    public static readonly DependencyProperty AutoScrollProperty =
        DependencyProperty.RegisterAttached(
            "AutoScroll",
            typeof(bool),
            typeof(ListBoxAutoScrollBehavior),
            new UIPropertyMetadata(false, OnAutoScrollChanged));

    public static bool GetAutoScroll(DependencyObject obj)
    {
        return (bool)obj.GetValue(AutoScrollProperty);
    }

    public static void SetAutoScroll(DependencyObject obj, bool value)
    {
        obj.SetValue(AutoScrollProperty, value);
    }

    public static void OnAutoScrollChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var listBox = d as ListBox;
        if (listBox == null) return;
        bool oldValue = (bool)e.OldValue, newValue = (bool)e.NewValue;
        if (newValue == oldValue) return;
        if (newValue)
        {
            listBox.Loaded += ListBox_Loaded;
            listBox.Unloaded += ListBox_Unloaded;
            var itemsSourcePropertyDescriptor = TypeDescriptor.GetProperties(listBox)["ItemsSource"];
            itemsSourcePropertyDescriptor.AddValueChanged(listBox, ListBox_ItemsSourceChanged);
        }
        else
        {
            listBox.Loaded -= ListBox_Loaded;
            listBox.Unloaded -= ListBox_Unloaded;
            if (Associations.ContainsKey(listBox))
                Associations[listBox].Dispose();
            var itemsSourcePropertyDescriptor = TypeDescriptor.GetProperties(listBox)["ItemsSource"];
            itemsSourcePropertyDescriptor.RemoveValueChanged(listBox, ListBox_ItemsSourceChanged);
        }
    }

    private static void ListBox_ItemsSourceChanged(object sender, EventArgs e)
    {
        var listBox = (ListBox)sender;
        if (Associations.ContainsKey(listBox))
            Associations[listBox].Dispose();
        Associations[listBox] = new Capture(listBox);
        HandlePossibleNotifyCollectionChanged(listBox);
    }

    private static void ListBox_Unloaded(object sender, RoutedEventArgs e)
    {
        var listBox = (ListBox)sender;
        if (Associations.ContainsKey(listBox))
            Associations[listBox].Dispose();
        listBox.Unloaded -= ListBox_Unloaded;
    }

    private static void ListBox_Loaded(object sender, RoutedEventArgs e)
    {
        var listBox = (ListBox)sender;
        HandlePossibleNotifyCollectionChanged(listBox);
    }

    private static void HandlePossibleNotifyCollectionChanged(ListBox sender)
    {
        var incc = sender.Items as INotifyCollectionChanged;
        if (incc == null) return;
        sender.Loaded -= ListBox_Loaded;
        var capture = new Capture(sender);
        Associations[sender] = capture;
        capture.Scroll();
    }

    private class Capture : IDisposable
    {
        private readonly INotifyCollectionChanged incc;
        private readonly ListBox listBox;

        public Capture(ListBox listBox)
        {
            this.listBox = listBox;
            this.incc = listBox.ItemsSource as INotifyCollectionChanged;
            if (this.incc != null) this.incc.CollectionChanged += this.incc_CollectionChanged;
        }

        public void Dispose()
        {
            if (this.incc != null) this.incc.CollectionChanged -= this.incc_CollectionChanged;
        }

        public void Scroll()
        {
            if (this.listBox.Items.Count > 0) this.listBox.ScrollIntoView(this.listBox.Items[^1]);
        }

        private void incc_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) this.listBox.ScrollIntoView(e.NewItems?[0]);
        }
    }
}