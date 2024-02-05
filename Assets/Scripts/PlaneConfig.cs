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
        private int _id;
        [SerializeField]
        private int _price;
        [SerializeField]
        private Sprite _sprite;
        [SerializeField]
        private Currency _paymentType;

        public int Id
        {
            get => _id;
        }
        public int Price
        {
            get => _price;
            set { _price = value; }
        }
        public Sprite Sprite
        {
            get => _sprite;
            set { _sprite = value; }
        }
        public Currency PaymentType
        {
            get => _paymentType;
            set { _paymentType = value; }
        }
    }
}