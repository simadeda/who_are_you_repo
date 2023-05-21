using FarrokhGames.SpriteAnimation.Shared;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarrokhGames.SpriteAnimation.Sprite
{
    /// <inheritdoc />
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : AbstractSpriteAnimator, ISpriteAnimator
    {
        SpriteRenderer _spriteRenderer;
        IAnimator[] _children;
        int _originalSortingOrder;

        private static int indice = 0;
        private SO_corpo_personaggio corpo_completo;
        /// <inheritdoc />
        protected override void Init()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalSortingOrder = _spriteRenderer.sortingOrder;
            _children = GetComponentsInChildren<IAnimator>().Where(x => !x.Equals(this)).ToArray();
        }
        public void fill_Sprites(List<UnityEngine.Transform> figli_player)
        {
            inizio_ciclo:
            if (indice < corpo_completo.parti_corpo_personaggio.Length)
            {
                if (corpo_completo.parti_corpo_personaggio[indice].parte_corpo.tutti_sprite_corpo.Count == 0 && indice != 0)
                    figli_player[indice - 1].gameObject.SetActive(false);
                else
                    for (int j = 0; j < corpo_completo.parti_corpo_personaggio[indice].parte_corpo.tutti_sprite_corpo.Count; j++)
                    {
                        _sprites[j] = corpo_completo.parti_corpo_personaggio[indice].parte_corpo.tutti_sprite_corpo[j];
                    }
                indice++;
                goto inizio_ciclo;
            } 
        } 
        /// <inheritdoc />
        protected override void HandleFrameChanged(int index)
        {
            _spriteRenderer.sprite = _sprites[index];
        }

        /// <inheritdoc />
        public bool Visible
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        /// <inheritdoc />
        public int SortingOrder
        {
            get { return _spriteRenderer.sortingOrder; }
            set
            {
                // Set sorting order of children
                if (_animateChildren && _children != null && _children.Length > 0)
                {
                    for (var i = 0; i < _children.Length; i++)
                    {
                        var child = _children[i];
                        if (child != null && child is ISpriteAnimator)
                        {
                            (child as ISpriteAnimator).SortingOrder = value;
                        }
                    }
                }
                _spriteRenderer.sortingOrder = value + _originalSortingOrder;
            }
        }

        /// <inheritdoc />
        public override bool Flip
        {
            get { return _spriteRenderer.flipX; }
            set
            {
                // Flip children
                if (_animateChildren && _children != null && _children.Length > 0)
                {
                    for (var i = 0; i < _children.Length; i++)
                    {
                        var child = _children[i];
                        if (child != null) { child.Flip = value; }
                    }
                }
                if (_allowFlipping) { _spriteRenderer.flipX = value; }
            }
        }

        public SO_corpo_personaggio Corpo_personaggio
        {
            set { corpo_completo = value; }
        }
    }
}