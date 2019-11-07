using System;
using System.Collections;
using System.Collections.Generic;

namespace Example_06.ChainOfResponsibility
{
    public enum CurrencyType
    {
        Eur,
        Dollar,
        Ruble
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    }

    public class Bancomat
    {
        private readonly IBanknoteHandler _handler;

        public Bancomat()
        {
            _handler = new BanknoteHandler(new DefaultHandler(), 10, CurrencyType.Ruble);
            _handler = new BanknoteHandler(_handler, 200, CurrencyType.Ruble);
            _handler = new BanknoteHandler(_handler, 1000, CurrencyType.Ruble);

            _handler = new BanknoteHandler(_handler, 10, CurrencyType.Dollar);
            _handler = new BanknoteHandler(_handler, 100, CurrencyType.Dollar);
        }

        public List<int> GiveMoney(int money, CurrencyType type)
        {

            return _handler.Handle(money, type, new List<int>());
        }
    }

    public interface IBanknoteHandler
    {
        List<int> Handle(int money, CurrencyType type, List<int> banknotes);
    }

    public class BanknoteHandler : IBanknoteHandler
    {
        private readonly IBanknoteHandler _nextHandler;
        private readonly int _banknoteValue;
        private readonly CurrencyType _type;

        public BanknoteHandler(IBanknoteHandler nextHandler, int banknoteValue, CurrencyType type)
        {
            _nextHandler = nextHandler;
            _banknoteValue = banknoteValue;
            _type = type;
        }

        public List<int> Handle(int money, CurrencyType type, List<int> banknotes)
        {
            if (type != _type)
            {
                return _nextHandler.Handle(money, type, banknotes);
            }

            while (money - _banknoteValue >= 0)
            {
                money -= _banknoteValue;
                banknotes.Add(_banknoteValue);
            }

            return _nextHandler.Handle(money, type, banknotes);
        }
    }

    public class DefaultHandler : IBanknoteHandler
    {
        public List<int> Handle(int money, CurrencyType type, List<int> banknotes)
        {
            if (money != 0)
            {
                throw new Exception("Невозможно выдать данную сумму");
            }

            return banknotes;
        }
    }
}