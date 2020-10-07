// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2149/judge/4895087/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
const char newl = '\n';
#define var auto

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);
  while(1){
    ll n, a, b, c, x;
    cin >> n >> a >> b >> c >> x;
    if (n == 0) break;
    vector<int> ys(n);
    for (int i = 0; i < n; i++){
      cin >> ys[i];
    }
    int cur = 0;
    int i;
    for (i = 0; i <= 10000; i++){
      if (ys[cur] == x) cur++;
      if (cur == n) break;
      x = (a * x + b) % c;
    }
    cout << (cur != n ? -1 : i) << endl;

  }
  return 0;
}

