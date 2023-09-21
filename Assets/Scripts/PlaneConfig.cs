using System;
using System.Collections.Generic;
using UnityEngine;

namespace CroakGames
{
    [CreateAssetMenu]
    public class PlaneConfig : ScriptableObject
    {
        [SerializeField]
        List<Plane> _planeList = new List<Plane>();

        public List<Plane> PlaneList => _planeList;
    }

    [Serializable]
    public class Plane
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _id;
        [SerializeField]
        private int _price;
        [SerializeField]
        private Sprite _sprite;
        [SerializeField]
        private Currency _paymentType;
        [SerializeField]
        private bool _unlocked;
        public bool Unlocked
        {
            get { return _unlocked; }
            set { _unlocked = value; }
        }
        public int Price   
        {
            get { return _price; }
            set { _price = value; }
        }
        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }
        public int PaymentType
        {
            get { return (int)_paymentType; }
            set { _paymentType = (Currency)value; }
        }
    }
}