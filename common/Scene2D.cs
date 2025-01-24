using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class Scene2D : Node2D {
    [Export] public SceneData sceneData;

    public void Save() {
        foreach (NodePath path in sceneData.data.Keys) {
            Node2D node = GetNodeOrNull<Node2D>(path);
            if (node == null) {
                GD.PrintErr("Node not found: " + path);
                continue;
            }

            Dictionary<string, Variant> nodeData = sceneData.data[path];
            foreach (string key in nodeData.Keys) {
                nodeData[key] = node.Get(key);
            }   
        }
    }

    public void Load() {
        foreach (NodePath path in sceneData.data.Keys) {
            Node2D node = GetNodeOrNull<Node2D>(path);
            if (node == null) {
                GD.PrintErr("Node not found: " + path);
                continue;
            }

            Dictionary<string, Variant> nodeData = sceneData.data[path];
            foreach (string key in nodeData.Keys) {
                node.Set(key, nodeData[key]);
            }   
        }
    }
}