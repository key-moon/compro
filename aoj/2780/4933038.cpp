// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2780/judge/4933038/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  int n;
  cin >> n;
  vector<int> a(n);
  for (int i = 0; i < n; i++){
    cin >> a[i];
  }
  int mx = -1;
  for (int i = 0; i < n; i++){
    for (int j = i + 1; j < n; j++){
      int d = a[i] * a[j];
      int ld = d % 10;
      d /= 10;
      while (d != 0){
        var nd = d % 10;
        if (ld - 1 != nd) goto end;
        ld = nd;
        d /= 10;
      } 
      chmax(mx, a[i] * a[j]);
      end:;
    }
  }
  cout << mx << endl;
}

