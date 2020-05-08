// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1322/judge/4445966/C++14
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}
using namespace std;

int h, w;
vector<string> expr;

template<typename T,T MOD = 1000000007>
struct Mint{
    static constexpr T mod = MOD;
    T v;
    Mint():v(0){}
    Mint(signed v):v(v){}
    Mint(long long t){v=t%MOD;if(v<0) v+=MOD;}

    Mint pow(long long k){
        Mint res(1),tmp(v);
        while(k){
            if(k&1) res*=tmp;
            tmp*=tmp;
            k>>=1;
        }
        return res;
    }

    static Mint add_identity(){return Mint(0);}
    static Mint mul_identity(){return Mint(1);}

    Mint inv(){return pow(MOD-2);}

    Mint& operator+=(Mint a){v+=a.v;if(v>=MOD)v-=MOD;return *this;}
    Mint& operator-=(Mint a){v+=MOD-a.v;if(v>=MOD)v-=MOD;return *this;}
    Mint& operator*=(Mint a){v=1LL*v*a.v%MOD;return *this;}
    Mint& operator/=(Mint a){return (*this)*=a.inv();}

    Mint operator+(Mint a) const{return Mint(v)+=a;}
    Mint operator-(Mint a) const{return Mint(v)-=a;}
    Mint operator*(Mint a) const{return Mint(v)*=a;}
    Mint operator/(Mint a) const{return Mint(v)/=a;}

    Mint operator-() const{return v?Mint(MOD-v):Mint(v);}

    bool operator==(const Mint a)const{return v==a.v;}
    bool operator!=(const Mint a)const{return v!=a.v;}
    bool operator <(const Mint a)const{return v <a.v;}

    static Mint comb(long long n,int k){
        Mint num(1),dom(1);
        for(int i=0;i<k;i++){
            num*=Mint(n-i);
            dom*=Mint(i+1);
        }
        return num/dom;
    }
};
template<typename T,T MOD> constexpr T Mint<T, MOD>::mod;
template<typename T,T MOD>
ostream& operator<<(ostream &os,Mint<T, MOD> m){os<<m.v;return os;}

using M = Mint<int, 2011>;

bool isBegin = true;

pair<M, int> parse(int baseY, int y1, int y2, int x1, int x2){
    //parse single expr
    if (baseY != -1){
        //fraction or unary -
        if (expr[baseY][x1] == '-'){
            if (expr[baseY][x1 + 1] == '.'){
                var afterExpr = parse(baseY, y1, y2, x1 + 2, -1);
                return make_pair(-afterExpr.first, afterExpr.second);
            }
            else{
                int x;
                for (x = x1; expr[baseY][x] == '-' && x < w; x++);
                x--;
                var resa = parse(-1, y1, baseY - 1, x1 + 1, x - 1).first;
                var resb = parse(-1, baseY + 1, y2, x1 + 1, x - 1).first;
                return make_pair(resa / resb, x);
            }
        }
        int x;
        M res;
        if (expr[baseY][x1] == '('){
            int depth = 0;
            for (x = x1; x < w; x++){
                depth += (expr[baseY][x] == '(' ? 1 : expr[baseY][x] == ')' ? -1 : 0);
                if (depth == 0) break;
            }
            res = parse(-1, y1, y2, x1 + 2, x - 2).first;
        }
        else{
            res = expr[baseY][x1] - '0';
            x = x1;
        }

        if (y1 <= baseY - 1 && x + 1 < w && expr[baseY - 1][x + 1] != '.') {
            res = res.pow(expr[baseY - 1][x + 1] - '0');
            x++;
        }
        return make_pair(res, x);
    }


    //find baseline
    while (true){
        for (int y = y1; y <= y2; y++){
            var c = expr[y][x1];
            if (c != '.'){
                baseY = y;
                break;
            }
        }
        if (baseY != -1){
            break;
        }
        x1++;
    }

    vector<M> num{};
    vector<char> op{};

    int x = x1;
    while (true){
        var res = parse(baseY, y1, y2, x, -1);
        if (!op.empty() && op[op.size() - 1] == '*'){
            op.pop_back();
            num[num.size() - 1] *= res.first;
        }
        else{
            num.push_back(res.first);
        }
        x = res.second;
        x += 2;
        if (x >= x2 || (expr[baseY][x] != '+' && expr[baseY][x] != '-' && expr[baseY][x] != '*')) break;
        op.push_back(expr[baseY][x]);
        x += 2;
    }

    M res = num[0];
    for (int i = 0; i < op.size(); i++){
        if (op[i] == '+') res += num[i + 1];
        else res -= num[i + 1];
    }

    return make_pair(res, -1);
}

bool solve(){
    cin >> h;
    if (h == 0) return false;
    expr = vector<string>(h);
    for (int i = 0; i < h; i++) cin >> expr[i];
    w = expr[0].size();
    cout << parse(-1, 0, h - 1, 0, w - 1).first << endl;
    return true;
}

signed main(){
    while(solve());
}

