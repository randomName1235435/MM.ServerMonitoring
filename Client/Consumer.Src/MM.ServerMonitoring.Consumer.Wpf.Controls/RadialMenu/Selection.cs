using System.Collections.Generic;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.RadialMenu;

internal class Selection
{
    private readonly List<int> _selection = new();

    public void SetSelection(int level, int selection)
    {
        // make sure internal list is long enough
        while (this._selection.Count < level + 1) this._selection.Add(-1);

        // set selection or deselect if same item is already selected
        if (this._selection[level] == selection)
            this._selection[level] = -1;
        else
            this._selection[level] = selection;

        // deselect items at higher level
        for (var i = level + 1; i < this._selection.Count; i++) this._selection[i] = -1;
    }

    public int GetSelection(int level)
    {
        if (level >= this._selection.Count) return -1;

        return this._selection[level];
    }

    public int GetLevel()
    {
        for (var i = this._selection.Count - 1; i >= 0; i--)
            if (this._selection[i] != -1)
                return i;
        return -1;
    }
}