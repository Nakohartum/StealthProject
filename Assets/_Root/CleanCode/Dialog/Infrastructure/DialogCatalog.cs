using System;
using System.Linq;
using _Root.CleanCode.Dialog.Domain;
using UnityEngine;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    [UnityEngine.CreateAssetMenu(fileName = nameof(DialogCatalog), menuName = "Create/Dialog/Catalog", order = 0)]
    public class DialogCatalog : ScriptableObject
    {
        public DialogScriptableObject[] Dialogs;

        public DialogModel FindDialog(string dialogId)
        {
            var dialogSo = Dialogs.First(d => d.DialogId == dialogId);
            if (dialogSo != null)
            {
                var parts = dialogSo.Parts.Select(p => new DialogPart
                {
                    Actor = p.Actor,
                    ImagePath = p.ImagePath,
                    Phrase = p.Phrase
                });
                return new DialogModel(dialogSo.DialogId, parts.ToArray(), dialogSo.IsInteractable);
            }
            return null;
        }
    }
}