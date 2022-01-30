using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using aplikacija1.Models;

namespace aplikacija1.Data
{
    public class HranaInitializer : System.Data.Entity.DropCreateDatabaseAlways<HranaContext>
    {
        protected override void Seed(HranaContext context)
        {
            var recepti = new List<Recept>
            {
                new Recept
                {
                    Naziv="Tjestenina s brokulom"
                },
                new Recept
                {
                    Naziv="Low carb krekeri"
                },
                new Recept
                {
                    Naziv="Smoothie od đumbira"
                },
                new Recept
                {
                    Naziv="Rižoto sa škampima"
                },
                new Recept
                {
                    Naziv="Raffaello kuglice"
                },
                new Recept
                {
                    Naziv="Pita od sira"
                },
                new Recept
                {
                    Naziv="Piletina s mozzarellom"
                },
                new Recept
                {
                    Naziv="Zapečene punjene paprike"
                },
                new Recept
                {
                    Naziv="Kokos čokoladne kocke"
                },
                new Recept
                {
                    Naziv="Rolice od tikvica"
                },
                new Recept
                {
                    Naziv="Domaći kruh s chia sjemenkama"
                },
                new Recept
                {
                    Naziv="Piletina punjena špinatom"
                },
            };
            recepti.ForEach(r => context.Recepti.Add(r));
            context.SaveChanges();

            var prehrane = new List<Prehrana>
            {
                new Prehrana
                {
                    Info="Kalorije"
                },
                new Prehrana
                {
                    Info="Mliječni proizvodi"
                },
                new Prehrana
                {
                    Info="Voda"
                },
                new Prehrana
                {
                    Info="Sol"
                },
                new Prehrana
                {
                    Info="Doručak"
                },
                new Prehrana
                {
                    Info="Šećer"
                },
                new Prehrana
                {
                    Info="Proteini"
                },
                new Prehrana
                {
                    Info="Tjelovježba"
                },
                new Prehrana
                {
                    Info="Ugljikohidrati"
                }
            };
            prehrane.ForEach(p => context.Prehrane.Add(p));
            context.SaveChanges();

            var popisi = new List<PopisRecepata>
            {
                new PopisRecepata
                {
                    Naziv="Tjestenina s brokulom",
                    Sastojak="tjestenina, sir, luk",
                    Sastojak2="brokule, ulje, limun, sol, papar",
                    Slozenost="zahtjevno"
                },
                new PopisRecepata
                {
                    Naziv="Low carb zobeni krekeri",
                    Sastojak="bademovo brašno, kokosovo brašno",
                    Sastojak2="zob, sol, voda",
                    Slozenost="jednostavno"
                },
                new PopisRecepata
                {
                    Naziv="Smoothie od đumbira i limuna",
                    Sastojak="đumbir, jabuka, šećer",
                    Sastojak2="limun, krastavac, celer",
                    Slozenost="jednostavno"

                },
                new PopisRecepata
                {
                    Naziv="Rižoto sa škampima",
                    Sastojak="riža, voda, maslac, ulje",
                    Sastojak2="škampi, sol, papar, luk",
                    Slozenost="zahtjevno"
                },
                new PopisRecepata
                {
                    Naziv="Raffaello kuglice s limunom",
                    Sastojak="kokos, orasi, kokosovo brašno",
                    Sastojak2="limun, ulje",
                    Slozenost="jednostavno"
                },
                new PopisRecepata
                {
                    Naziv="Zobena pita od sira",
                    Sastojak="sir, jogurt, jaja, sol",
                    Sastojak2="zob, brašno, orasi",
                    Slozenost="zahtjevno"

                },
                new PopisRecepata
                {
                    Naziv="Piletina s mozzarellom",
                    Sastojak="piletina, paprika, rajčica",
                    Sastojak2="sir, ulje, sol, papar",
                    Slozenost="zahtjevno"

                },
                new PopisRecepata
                {
                    Naziv="Zapečene punjene paprike",
                    Sastojak="junetina, tikvica, luk, ulje",
                    Sastojak2="paprika, jaje, feta sir, sol, kus-kus",
                    Slozenost="jednostavno"

                },
                new PopisRecepata
                {
                    Naziv="Kokos čokoladne kocke",
                    Sastojak="kokosovo brašno, sol, kokosovo ulje",
                    Sastojak2="kakao, orasi",
                    Slozenost="zahtjevno"

                },
                new PopisRecepata
                {
                    Naziv="Rolice od tikvica",
                    Sastojak="tikvice, ulje, sol, papar",
                    Sastojak2="posni sir, feta sir, bosiljak",
                    Slozenost="zahtjevno"

                },
                new PopisRecepata
                {
                    Naziv="Domaći kruh s chia sjemenkama",
                    Sastojak="chia sjemenke, brašno, voda",
                    Sastojak2="jaja, sol, papar, jogurt",
                    Slozenost="zahtjevno"

                },
                new PopisRecepata
                {
                    Naziv="Piletina punjena špinatom",
                    Sastojak="piletina, ulje, sir",
                    Sastojak2="špinat, mozzarella, sol",
                    Slozenost="zahtjevno"

                },
            };
            popisi.ForEach(pr => context.PopisiRecepata.Add(pr));
            context.SaveChanges();

            var sastojci = new List<Sastojak>
            {
                new Sastojak
                {
                    Naziv="piletina"
                },
                new Sastojak
                {
                    Naziv="tjestenina"
                },
                new Sastojak
                {
                    Naziv="sir"
                },
                new Sastojak
                {
                    Naziv="luk"
                },
                new Sastojak
                {
                    Naziv="kokosovo brašno"
                },
                new Sastojak
                {
                    Naziv="zobene pahuljice"
                },
                new Sastojak
                {
                    Naziv="maslinovo ulje"
                },
                new Sastojak
                {
                    Naziv="tikvice"
                },
                new Sastojak
                {
                    Naziv="papar"
                },
                new Sastojak
                {
                    Naziv="jaja"
                },
                new Sastojak
                {
                    Naziv="špinat"
                },
                new Sastojak
                {
                    Naziv="đumbir"
                },
                new Sastojak
                {
                    Naziv="paprika"
                },
                new Sastojak
                {
                    Naziv="rajčica"
                },
                new Sastojak
                {
                    Naziv="chia sjemenke"
                },
                new Sastojak
                {
                    Naziv="junetina"
                },
                new Sastojak
                {
                    Naziv="škampi"
                },
                new Sastojak
                {
                    Naziv="riža"
                },
                new Sastojak
                {
                    Naziv="limun"
                },
                new Sastojak
                {
                    Naziv="brokule"
                },
                new Sastojak
                {
                    Naziv="kakao"
                }
            };
            sastojci.ForEach(s => context.Sastojci.Add(s));
            context.SaveChanges();

            var omiljenir = new List<Omiljeni>
            {
                new Omiljeni
                {
                    SastojakID=1,
                    PopisRecepataID=2
                }
            };
            omiljenir.ForEach(or => context.OmiljeniR.Add(or));
            context.SaveChanges();
        }
    }
}