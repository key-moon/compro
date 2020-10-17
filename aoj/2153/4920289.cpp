// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2153/judge/4920289/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

int main(){
    int w, h;
    cin >> w >> h;
    if (w == 0) return 0;
    vector<string> lg(h + 2);
    vector<string> rg(h + 2);
    lg[0] = lg[h + 1] = rg[0] = rg[h + 1] = string(w + 2, '#');
    for (int i = 1; i <= h; i++){
        cin >> lg[i] >> rg[i];
        lg[i] = "#" + lg[i] + "#";
        rg[i] = "#" + rg[i] + "#";
        reverse(rg[i].begin(), rg[i].end());
    }

    int ldsty, ldstx, rdsty, rdstx, lsty, lstx, rsty, rstx;

    var findc = [&](vector<string>& g, char c, int& y, int& x){
        for (int i = 1; i <= h; i++){
            for (int j = 1; j <= w; j++){
                if (g[i][j] == c){
                    y = i;
                    x = j;
                }
            }
        }
    };

    findc(lg, 'L', lsty, lstx);
    findc(rg, 'R', rsty, rstx);
    findc(lg, '%', ldsty, ldstx);
    findc(rg, '%', rdsty, rdstx);

    vector<vector<vector<vector<bool>>>> reached(h + 2, vector<vector<vector<bool>>>(w + 2, vector<vector<bool>>(h + 2, vector<bool>(w + 2))));
    using P = pair<int, int>;
    using PP = pair<P, P>;
    stack<PP> st{};
    st.push(PP(P(lsty, lstx), P(rsty, rstx)));
    reached[lsty][lstx][rsty][rstx] = true;
    vector<int> dys = { 0, -1, 0, 1 };
    vector<int> dxs = { -1, 0, 1, 0 };
    bool possible = false;
    while (!st.empty()){
        var elem = st.top(); st.pop();
        var l = elem.first, r = elem.second;
        var ly = l.first, lx = l.second, ry = r.first, rx = r.second;
        for (int i = 0; i < 4; i++){
            var nly = ly + dys[i], nlx = lx + dxs[i];
            var nry = ry + dys[i], nrx = rx + dxs[i];
            if (lg[nly][nlx] == '#') nly -= dys[i], nlx -= dxs[i];
            if (rg[nry][nrx] == '#') nry -= dys[i], nrx -= dxs[i];
            if (reached[nly][nlx][nry][nrx]) continue;
            var reachl = nly == ldsty && nlx == ldstx;
            var reachr = nry == rdsty && nrx == rdstx;
            if (reachl ^ reachr) continue;
            possible |= reachl & reachr;
            reached[nly][nlx][nry][nrx] = true;
            st.push(PP(P(nly, nlx), P(nry, nrx)));
        }
    }
    cout << (possible ? "Yes" : "No") << endl;
    main();
}

