// detail: https://atcoder.jp/contests/yahoo-procon2019-qual/submissions/20445208
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll k, a, b;
  cin >> k >> a >> b;
  if (b - a <= 1) {
    cout << (1 + k) << endl;
    return 0;
  }
  var biscket = 1LL;
  var op1 = min(k, a - 1);
  k -= op1;
  biscket += op1;
  if (k & 1) {
    k--;
    biscket++;
  }
  biscket += (b - a) * (k / 2);
  cout << biscket << endl;
}
