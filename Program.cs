namespace VehiculeAbstractFactory;

// classe abstraite de base
public abstract class FabriqueVehicule
{
    public abstract Véhicule CréerVoiture();
    public abstract Scooter CréerScooter();
}

// classe concrète véhicule électrique
public class FabriqueVehiculeElectrique : FabriqueVehicule
{
    public override Véhicule CréerVoiture()
    {
        return new VoitureElectrique();
    }

    public override Scooter CréerScooter()
    {
        return new ScooterElectrique();
    }
}

// classe concrète véhicule essence
public class FabriqueVehiculeEssence : FabriqueVehicule
{
    public override Véhicule CréerVoiture()
    {
        return new VoitureEssence();
    }

    public override Scooter CréerScooter()
    {
        return new ScooterEssence();
    }
}

// classe abstraite véhicule
public abstract class Véhicule
{
    public string? Nom { get; protected set; }
    public string? TypeCarburant { get; protected set; }

    protected Véhicule(string nom, string typeCarburant)
    {
        Nom = nom;
        TypeCarburant = typeCarburant;
    }
}

// classe abstraite scooter
public abstract class Scooter
{
    public string Nom { get; protected set; }
    public string TypeCarburant { get; protected set; }

    protected Scooter(string nom, string typeCarburant)
    {
        Nom = nom;
        TypeCarburant = typeCarburant;
    }
}

// classe véhicule électrique
public class VoitureElectrique : Véhicule
{
    public VoitureElectrique() : base("Voiture Électrique", "électrique") { }
}

// classe véhicule essence
public class VoitureEssence : Véhicule
{
    public VoitureEssence() : base("Voiture Essence", "essence") { }
}

// classe véhicule électrique
public class ScooterElectrique : Scooter
{
    public ScooterElectrique() : base("Scooter Electrique", "électrique") { }
}

// classe véhicule essence
public class ScooterEssence : Scooter
{
    public ScooterEssence() : base("Scooter Essence", "essence") { }
}

// classe catalogue
public class Catalogue
{
    private Véhicule _vehicule;
    private Scooter _scooter;

    public Catalogue(FabriqueVehicule fabrique)
    {
        _vehicule = fabrique.CréerVoiture();
        _scooter = fabrique.CréerScooter();
    }

    public void AfficherCarac()
    {
        Console.WriteLine($"Véhicule: {_vehicule.Nom}, Type de carburant: {_vehicule.TypeCarburant}");
        Console.WriteLine($"Scooter: {_scooter.Nom}, Type de carburant: {_scooter.TypeCarburant}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Quel type de véhicule voulez-vous ?");
        
        switch (Console.ReadLine().ToLower())
        {
            case "voiture":
                Console.WriteLine("Quel type de carburant voulez-vous ?");
                switch (Console.ReadLine().ToLower())
                {
                    case "electrique":
                        FabriqueVehicule fabrique = new FabriqueVehiculeElectrique();
                        Catalogue catalogue = new Catalogue(fabrique);
                        catalogue.AfficherCarac();
                        break;
                    case "essence":
                        fabrique = new FabriqueVehiculeEssence();
                        catalogue = new Catalogue(fabrique);
                        catalogue.AfficherCarac();
                        break;
                }
                break;
            case "scooter":
                Console.WriteLine("Quel type de carburant voulez-vous ?");
                switch (Console.ReadLine().ToLower())
                {
                    case "electrique":
                        FabriqueVehicule fabrique = new FabriqueVehiculeElectrique();
                        Catalogue catalogue = new Catalogue(fabrique);
                        catalogue.AfficherCarac();
                        break;
                    case "essence":
                        fabrique = new FabriqueVehiculeEssence();
                        catalogue = new Catalogue(fabrique);
                        catalogue.AfficherCarac();
                        break;
                }
                break;
            default:
                Console.WriteLine("Choix invalide, choix possible : 'Voiture' ou 'Scooter'");
                break;
        }

      
    }
}
