using _Root.Code.CutsceneFeature.Model;
using _Root.Code.CutsceneFeature.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Root.Code.CutsceneFeature.View
{
    public class CutsceneView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private Image _portrait;
        [SerializeField] private TMP_Text _characterName;
        
        private CutscenePresenter _cutscenePresenter;

        public void Construct(CutscenePresenter presenter)
        {
            _cutscenePresenter = presenter;
            gameObject.SetActive(true);
        }

        public void ShowStep(CutscenePart step)
        {
            _dialogueText.text = step.Dialog;
            _portrait.sprite = step.CharacterSprite;
            _characterName.text = step.CharacterName;
        }

        public void EndCutscene()
        {
            gameObject.SetActive(false);
        }

        public class CutsceneFactory : PlaceholderFactory<CutsceneView>{}
    }
}