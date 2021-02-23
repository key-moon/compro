// detail: https://atcoder.jp/contests/agc041/submissions/20439667
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n, a, b;
  cin >> n >> a >> b;
  if ((a - b) & 1) {
    var calc = [](ll a, ll b) {
      return (a + b + 1) / 2;
    };
    cout << min(calc(a - 1, b - 1), calc(n - a, n - b)) << endl;
  }
  else {
    cout << abs(a - b) / 2 << endl;
  }
}
