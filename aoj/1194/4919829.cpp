// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1194/judge/4919829/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

int main(){
    int n, r;
    cin >> r >> n;
    if (r == 0) return 0;
    vector<int> maxh(r * 2);
    for (int i = 0; i < n; i++){
        int x1, x2, h;
        cin >> x1 >> x2 >> h;
        for (int i = max(0, x1 + r); i < min(r * 2, x2 + r); i++){
            chmax(maxh[i], h);
        }
    }
    double res = 114514;
    var initpos = -r;
    for (int i = 0; i < r; i++){
        var h = min(maxh[r + i], maxh[r - i - 1]);
        var pos = h - sqrt(r * r - i * i);
        chmin(res, pos - initpos);
    }
    cout << fixed << setprecision(4);
    cout << res << endl;
    main();
}

