// detail: https://codeforces.com/contest/825/submission/108144562
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n; ll k;
  cin >> n >> k;
  vector<ll> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  int res = 0;
  sort(a.begin(), a.end());
  for (int i = 0; i < n; i++) {
    var elem = a[i];
    while (k * 2 < elem) {
      k = k * 2;
      res++;
    }
    chmax(k, elem);
  }
  cout << res << endl;
}
