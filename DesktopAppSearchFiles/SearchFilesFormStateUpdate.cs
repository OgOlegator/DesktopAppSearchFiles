using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppSearchFiles
{
    public partial class SearchFilesForm
    {
        private StateUpdate _stateUpdate = new StateUpdate();

        private sealed class StateUpdate
        {
            public enum TypeStateUpdate
            {
                None,
                Stop,
                Progress
            }

            public StateUpdate()
            {
                _state = TypeStateUpdate.None;
            }

            private TypeStateUpdate _state;

            public TypeStateUpdate GetState()
                => _state;

            public void StopUpdate()
                => _state = TypeStateUpdate.Stop;

            public void StartUpdate()
                => _state = TypeStateUpdate.Progress;

            public void ResetUpdate()
                => _state = TypeStateUpdate.None;
        }

    }
}
