using FarrokhGames.SpriteAnimation.Shared;
using System.Linq;
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

        [SerializeField] private SO_corpo_personaggio corpo_completo;

        /// <inheritdoc />
        protected override void Init()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalSortingOrder = _spriteRenderer.sortingOrder;
            _children = GetComponentsInChildren<IAnimator>().Where(x => !x.Equals(this)).ToArray();
            fill_Sprites();
        }

        protected void fill_Sprites()
        {
             //indice; indice < corpo_completo.parti_corpo_personaggio.Length;
             if(indice < corpo_completo.parti_corpo_personaggio.Length)
             {
                if (corpo_completo.parti_corpo_personaggio[indice].parte_corpo.tutti_sprite_corpo.Count == 0)
                    this.gameObject.SetActive(false);
                else
                for (int j = 0; j < corpo_completo.parti_corpo_personaggio[indice].parte_corpo.tutti_sprite_corpo.Count; j++)
                {
                    _sprites[j] = corpo_completo.parti_corpo_personaggio[indice].parte_corpo.tutti_sprite_corpo[j];
                }
                indice++;
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
    }
}