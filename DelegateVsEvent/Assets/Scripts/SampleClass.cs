using System;

public class SampleClass1
{
    public delegate void OrnekDelegateOld(int value1, int value2);

    public delegate string OrnenDelegateOld1(int value1, int value2);

    //
    // public event OrnekDelega OrnekEvent;
    public Action<int, int> OrnekDelegateNew;
    public Action OrnekOrnekDelegate;

    public Func<int, int, string> OrnekDelegateNew1;
    //public event Action OrnekEventNew;

    //public OrnekDelega OrnekDelegaPro { get; set; }

    public event System.Action OnTookDamage;

    public SampleClass1()
    {
    }

    public void Method()
    {
    }

    public void Method1()
    {
    }

    public void Method2()
    {
        OrnekOrnekDelegate.Invoke();
    }

    public string Method3(int value1, int value2)
    {
        return null;
    }

    int _currentHealth;

    public void HealthProcess(int healthValue, Action successHealthCallback = null)
    {
        _currentHealth += healthValue;

        if (_currentHealth > healthValue)
        {
            //if (successHealthCallback != null) successHealthCallback();
            successHealthCallback?.Invoke();    
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        OnTookDamage?.Invoke();
    }
}

public class SampleClass2
{
    public SampleClass2()
    {
        SampleClass1 sampleClass1 = new SampleClass1();
        // sampleClass1.OrnekDelegaPro = new SampleClass1.OrnekDelega(Method);
        // sampleClass1.OrnekDelegaPro();
        //
        // sampleClass1.OrnekEvent += Method;
        // sampleClass1.OrnekEvent.
        sampleClass1.OrnekOrnekDelegate = new Action(PrivateMethod);
        sampleClass1.HealthProcess(10, () =>
        {
            
        });

        sampleClass1.OnTookDamage += Method;
        sampleClass1.OnTookDamage += () => { };
        //sampleClass1.OnTookDamage();
    }

    public void Method()
    {
    }

    private void PrivateMethod()
    {
        
    }
}