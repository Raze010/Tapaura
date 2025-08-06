

public class Chasseur {
    private static readonly Lazy<Chasseur> lazy = new Lazy<Chasseur>(() => new Chasseur());
    public static Chasseur Instance { get { return lazy.Value; } }

    public float PV = 30, PVMax = 30;

    public float DgtFrappe = 1, DgtAura = 0;

    public float CalcCarac () {
        PVMax = 30;

        DgtFrappe = 1;
        DgtAura = 0;
    }
}