using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.FilterableComboBox;

public class FilterableComboBox : ComboBox
{
    public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register(
        nameof(Watermark),
        typeof(object),
        typeof(FilterableComboBox));

    public static readonly DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register(
        nameof(WatermarkTemplate),
        typeof(DataTemplate),
        typeof(FilterableComboBox));


    public static readonly DependencyProperty IsCaseSensitiveProperty =
        DependencyProperty.Register(
            nameof(IsCaseSensitive),
            typeof(bool),
            typeof(FilterableComboBox),
            new UIPropertyMetadata(false));

    public static readonly DependencyProperty DropDownOnFocusProperty =
        DependencyProperty.Register(nameof(DropDownOnFocus),
            typeof(bool),
            typeof(FilterableComboBox),
            new UIPropertyMetadata(true));

    private ICollectionView _collView;

    private int _length;

    // private string _savedText;
    private int _silenceEvents;

    private int _start;
    // private bool _textSaved;

    public FilterableComboBox()
    {
        var textProperty = DependencyPropertyDescriptor.FromProperty(
            TextProperty,
            typeof(FilterableComboBox));
        textProperty.AddValueChanged(this, this.OnTextChanged);
        this.RegisterIsCaseSensitiveChangeNotification();
    }


    public object Watermark
    {
        get => this.GetValue(WatermarkProperty);
        set => this.SetValue(WatermarkProperty, value);
    }

    public DataTemplate WatermarkTemplate
    {
        get => (DataTemplate)this.GetValue(WatermarkTemplateProperty);
        set => this.SetValue(WatermarkTemplateProperty, value);
    }

    [DefaultValue(true)]
    public bool IsCaseSensitive
    {
        [DebuggerStepThrough] get => (bool)this.GetValue(IsCaseSensitiveProperty);
        [DebuggerStepThrough] set => this.SetValue(IsCaseSensitiveProperty, value);
    }

    [DefaultValue(true)]
    public bool DropDownOnFocus
    {
        [DebuggerStepThrough] get => (bool)this.GetValue(DropDownOnFocusProperty);
        [DebuggerStepThrough] set => this.SetValue(DropDownOnFocusProperty, value);
    }

    private TextBox EditableTextBox => (TextBox)this.GetTemplateChild("PART_EditableTextBox");

    private Popup ItemsPopup => (Popup)this.GetTemplateChild("PART_Popup");

    private ScrollViewer ItemsScrollViewer
    {
        get
        {
            var border = ItemsPopup.FindName("DropDownBorder") as Border;
            if (border == null) return null;
            return border.Child as ScrollViewer;
        }
    }

    protected virtual void OnIsCaseSensitiveChanged(object sender,
        EventArgs e)
    {
        if (IsCaseSensitive)
            IsTextSearchEnabled = false;
        this.RefreshFilter();
    }

    private void RegisterIsCaseSensitiveChangeNotification()
    {
        DependencyPropertyDescriptor.FromProperty(
            IsCaseSensitiveProperty,
            typeof(FilterableComboBox)).AddValueChanged(
            this, this.OnIsCaseSensitiveChanged);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        if (EditableTextBox != null)
            EditableTextBox.SelectionChanged += this.EditableTextBox_SelectionChanged;
        ItemsPopup.Focusable = true;
    }

    private void EditableTextBox_SelectionChanged(object sender,
        RoutedEventArgs e)
    {
        var origTextBox = (TextBox)e.OriginalSource;
        var origStart = origTextBox.SelectionStart;
        var origLength = origTextBox.SelectionLength;

        if (this._silenceEvents > 0) return;
        this._start = origStart;
        this._length = origLength;
        this.RefreshFilter();
        this.ScrollItemsToTop();
    }

    private void RestoreSavedText()
    {
        //Text = this._textSaved ? this._savedText : "";
        EditableTextBox.SelectAll();
    }

    private void ClearFilter()
    {
        this._length = 0;
        this._start = 0;
        this.RefreshFilter();
        Text = "";
        this.ScrollItemsToTop();
    }

    private void SilenceEvents()
    {
        ++this._silenceEvents;
    }

    private void UnSilenceEvents()
    {
        if (this._silenceEvents > 0)
            --this._silenceEvents;
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
        base.OnGotFocus(e);
        if (ItemsSource == null) return;
        if (DropDownOnFocus)
            IsDropDownOpen = true;
    }

    protected override void OnPreviewLostKeyboardFocus(
        KeyboardFocusChangedEventArgs e)
    {
        if (Text.Length == 0)
            this.RestoreSavedText();
        // else if (SelectedItem != null) this._savedText = SelectedItem.ToString();
        base.OnPreviewLostKeyboardFocus(e);
    }

    private void ScrollItemsToTop()
    {
        var scrollViewer = ItemsScrollViewer;
        if (scrollViewer == null) return;
        scrollViewer.ScrollToTop();
    }

    private void RefreshFilter()
    {
        if (ItemsSource == null) return;
        this._collView = CollectionViewSource.GetDefaultView(ItemsSource);
        this._collView.Refresh();
        IsDropDownOpen = true;
    }

    private bool FilterPredicate(object value)
    {
        if (value == null) return false;

        if (Text.Length == 0)
            return true;

        var prefix = Text;

        if (this._length > 0 && this._start + this._length == Text.Length) prefix = prefix.Substring(0, this._start);

        if (value is IFilterableItemViewModel filterable) return filterable.Contains(prefix);

        return value.ToString().Contains(prefix, StringComparison.CurrentCultureIgnoreCase);
    }


    protected override void OnItemsSourceChanged(
        IEnumerable oldValue,
        IEnumerable newValue)
    {
        if (newValue != null)
        {
            this._collView = CollectionViewSource.GetDefaultView(newValue);
            this._collView.Filter += this.FilterPredicate;
        }

        if (oldValue != null)
        {
            this._collView = CollectionViewSource.GetDefaultView(oldValue);
            this._collView.Filter -= this.FilterPredicate;
        }

        base.OnItemsSourceChanged(oldValue, newValue);
    }

    private void OnTextChanged(object sender, EventArgs e)
    {
        //if (!this._textSaved)
        //{
        //    this._savedText = Text;
        //    this._textSaved = true;
        //}

        if (IsTextSearchEnabled || this._silenceEvents != 0) return;

        this.RefreshFilter();

        if (Text.Length <= 0) return;
        var prefix = Text.Length;
        this._collView = CollectionViewSource.GetDefaultView(ItemsSource);
        foreach (var item in this._collView)
        {
            try
            {
                var text = item.ToString().Length;
                SelectedItem = item;

                this.SilenceEvents();
                EditableTextBox.Text = item.ToString();
                EditableTextBox.Select(prefix, text - prefix);
            }
            finally
            {
                this.UnSilenceEvents();
            }

            break;
        }
    }

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Enter:
            case Key.Tab:
                IsDropDownOpen = false;
                if (string.IsNullOrEmpty(Text))
                    SelectedItem = null;
                break;
            case Key.Escape:
                this.UnSilenceEvents();
                this.ClearFilter();
                IsDropDownOpen = true;
                return;
            case Key.Down:
            case Key.Up:
                IsDropDownOpen = true;
                break;
        }

        base.OnPreviewKeyDown(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Escape:
                this.UnSilenceEvents();
                this.ClearFilter();
                IsDropDownOpen = true;
                return;
        }

        base.OnKeyDown(e);
    }
}