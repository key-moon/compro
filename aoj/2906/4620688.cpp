// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2906/judge/4620688/C++14
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}
using namespace std;

int main(){
    int c, n, m;
    cin >> c >> n >> m;
    vector<ll> maxPrice(c + 1, 0);
    for (int ctr = 0; ctr < n; ctr++){
        int w, v;
        cin >> w >> v;
        for (int i = maxPrice.size() - 1; i >= w; i--){
            chmax(maxPrice[i], maxPrice[i - w] + v);
        }
    }
    for (int i = 1; i <= m; i++){
        cout << maxPrice[c / i] * i << endl;
    }
}
