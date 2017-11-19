using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Utils {
    public class Perlin {
        //linear congruential generator parameters
        long M = 4294967296,
             A = 1664525,
             C = 1;

        ////psuedo-random number generator (linear congruential)
        //public void PSNG() {
        //    this.Z = Math.floor(Math.random() * M);
        //    this.next = function(){
        //        this.Z = (A * this.Z + C) % M;
        //        return this.Z / M - 0.5;
        //    }
        //}

        ////cosine interpolation
        //public void Interpolate(pa, pb, px) {
        //    var ft = px * Math.PI;
        //    var f = (1 - Math.cos(ft)) * 0.5;
        //    return pa * (1 - f) + pb * f;
        //}

        ////1D perlin line generator
        //function Perlin(amp, wl, width) {
        //    this.x = 0;
        //    this.amp = amp;
        //    this.wl = wl;
        //    this.fq = 1 / wl;
        //    this.psng = new PSNG();
        //    this.a = this.psng.next();
        //    this.b = this.psng.next();
        //    this.pos = [];
        //    while (this.x < width) {
        //        if (this.x % this.wl === 0) {
        //            this.a = this.b;
        //            this.b = this.psng.next();
        //            this.pos.push(this.a * this.amp);
        //        } else {
        //            this.pos.push(Interpolate(this.a, this.b, (this.x % this.wl) / this.wl) * this.amp);
        //        }
        //        this.x++;
        //    }
        //}
    }
}
