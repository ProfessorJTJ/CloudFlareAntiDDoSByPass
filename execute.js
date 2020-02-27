var
    Key1 = DefaltValue
    ,
    Key2 = StrangeKey
    ;

var s, t, o, p = 0, b, r, a, k, i, n, g, f, Handler = { "HanderKey": 0 };

var e = function (s) {
    s += "==".slice(2 - (s.length & 3));
    var bm, r = "", r1, r2, i = 0;
    for (; i < s.length;) {
        bm = o.indexOf(s.charAt(i++)) << 18 | o.indexOf(s.charAt(i++)) << 12
                | (r1 = o.indexOf(s.charAt(i++))) << 6 | (r2 = o.indexOf(s.charAt(i++)));
        r += r1 === 64 ? g(bm >> 16 & 255)
                : r2 === 64 ? g(bm >> 16 & 255, bm >> 8 & 255)
                : g(bm >> 16 & 255, bm >> 8 & 255, bm & 255);
    }
    return r;
};

function GetResult() {
    g = String.fromCharCode;
 
    t = "bttdm.com"; // change to ur desired domain
    Handler.HanderKey = Key1;

    CalCulations
    
    return (+Handler.HanderKey).toFixed(10);
}
