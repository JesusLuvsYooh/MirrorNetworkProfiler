using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using UnityEngine;
using UnityEditorInternal;
using UnityEngine.UIElements;
using UnityEditor;
using Unity.VisualScripting;

public class MNPViewController : ProfilerModuleViewController
{
    // Define a label, which will display the total particle count for tank trails in the selected frame.
    Label commandCountLabel;

    // Define a constructor for the view controller, which calls the base constructor with the Profiler Window passed from the module.
    public MNPViewController(ProfilerWindow profilerWindow) : base(profilerWindow) { }

    // Override CreateView to build the custom module details panel.
    protected override VisualElement CreateView()
    {
        var view = new VisualElement();

        // Create the label and add it to the view.
        commandCountLabel = new Label() { style = { paddingTop = 8, paddingLeft = 8 } };
        view.Add(commandCountLabel);

        // Populate the label with the current data for the selected frame. 
        ReloadData();

        // Be notified when the selected frame index in the Profiler Window changes, so we can update the label.
        ProfilerWindow.SelectedFrameIndexChanged += OnSelectedFrameIndexChanged;

        return view;
    }

    // Override Dispose to do any cleanup of the view when it is destroyed. This is a standard C# Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (!disposing)
            return;

        // Unsubscribe from the Profiler window event that we previously subscribed to.
        ProfilerWindow.SelectedFrameIndexChanged -= OnSelectedFrameIndexChanged;

        base.Dispose(disposing);
    }

    void ReloadData()
    {
        // Retrieve the TankTrailParticleCount counter value from the Profiler as a formatted string.
        var selectedFrameIndexInt32 = System.Convert.ToInt32(ProfilerWindow.selectedFrameIndex);
        var value = ProfilerDriver.GetFormattedCounterValue(selectedFrameIndexInt32, NetworkStats.MirrorNetworkProfiler.Name, NetworkStats.MirrorNetworkProfiler.Name);

        // Update the label's text with the value.
        commandCountLabel.text = $"The value of ' " + NetworkStats.CommandCount + " in the selected frame is {value}.";
    }

    void OnSelectedFrameIndexChanged(long selectedFrameIndex)
    {
        // Update the label with the current data for the newly selected frame.
        ReloadData();
    }
}