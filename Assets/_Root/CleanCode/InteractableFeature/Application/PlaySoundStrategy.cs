using _Root.CleanCode.InteractableFeature.Application.Ports;
using _Root.CleanCode.InteractableFeature.Domain;
using _Root.CleanCode.Shared.Ports.Sounds;

namespace _Root.CleanCode.InteractableFeature.Application
{
    public class PlaySoundStrategy : IInteractionStrategy
    {
        private InteractableModel _model;
        private InteractableObjectState _state;
        private ISoundPort _soundPort;

        public PlaySoundStrategy(InteractableModel model, ISoundPort soundPort, InteractableObjectState state)
        {
            _model = model;
            _soundPort = soundPort;
            _state = state;
        }

        public void Interact()
        {
            if (_state.IsSoundPlaying)
            {
                _soundPort.Stop(_model.ContinuousSoundKey);
                _soundPort.PlayOneShot(_model.StopSoundKey);
            }
            else
            {
                _soundPort.PlayOneShot(_model.StartSoundKey);
                _soundPort.PlayDelayed(_model.ContinuousSoundKey);
            }
        }

        public void Initialize()
        {
            _soundPort.PreloadSound(_model.StartSoundKey);
            _soundPort.PreloadSound(_model.ContinuousSoundKey);
            _soundPort.PreloadSound(_model.StopSoundKey);
        }
    }
}