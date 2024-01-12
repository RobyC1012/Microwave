using System;

namespace Microwave;

public interface IAfisaj_Microunde
{
    public void setGatesteOn();
    public void setGatesteOff();
    public void setUsaDeschisa();
    public void setUsaInchisa();
    public void setTimpRamas(int time);
}