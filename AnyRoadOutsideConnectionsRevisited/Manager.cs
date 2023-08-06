namespace AnyRoadOutsideConnectionsRevisited;
using System.Collections.Generic;

internal class Manager : SingletonManager<Manager> {
    private BuildingInfo connection;
    private readonly Queue<RoadBaseAI> InfoQueue = new();

    public override bool IsInit { get; set; }
    public bool IsNetworkAnarchyEnabled { get; } = PluginManagerExtension.IsPluginEnabled("NetworkAnarchy");

    public override void DeInit() { }
    public override void Init() { }

    public void PostInitialization(NetInfo info) {
        if (IsNetworkAnarchyEnabled || info == null || info.m_netAI is not RoadBaseAI) {
            return;
        }
        var roadAi = (RoadBaseAI)info.m_netAI;
        if (roadAi.m_outsideConnection == null && connection == null) {
            InfoQueue.Enqueue(roadAi);
        } else {
            if (roadAi.m_outsideConnection == null) {
                Process(roadAi);
            } else {
                if (connection == null) {
                    connection = roadAi.m_outsideConnection;
                }
            }
            while (InfoQueue.Count > 0) {
                Process(InfoQueue.Dequeue());
            }
        }
    }

    private void Process(RoadBaseAI ai) {
        ai.m_outsideConnection = connection;
    }

    public void Reset() {
        connection = null;
        InfoQueue.Clear();
    }
}
