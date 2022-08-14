using System.Collections.Generic;

namespace AnyRoadOutsideConnectionsRevisited {
    public class Manager {
        private static BuildingInfo _connection;
        private static readonly Queue<RoadBaseAI> InfoQueue = new Queue<RoadBaseAI>();

        public static void Reset() {
            _connection = null;
            InfoQueue.Clear();
        }

        internal static void PostInitialization(NetInfo info) {
            if (info == null || !(info.m_netAI is RoadBaseAI)) {
                return;
            }
            var roadAi = (RoadBaseAI)info.m_netAI;
            if (roadAi.m_outsideConnection == null && _connection == null) {
                InfoQueue.Enqueue(roadAi);
            } else {
                if (roadAi.m_outsideConnection == null) {
                    Process(roadAi);
                } else {
                    if (_connection == null) {
                        _connection = roadAi.m_outsideConnection;
                    }
                }
                while (InfoQueue.Count > 0) {
                    Process(InfoQueue.Dequeue());
                }
            }
        }
        private static void Process(RoadBaseAI ai) {
            ai.m_outsideConnection = _connection;
        }

    }
}
