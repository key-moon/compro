// detail: https://atcoder.jp/contests/agc028/submissions/20448589
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

ll gcd(ll a, ll b) {
  return a == 0 ? b : gcd(b % a, a);
}

int main() {
  ll n, m;
  cin >> n >> m;
  string s, t;
  cin >> s >> t;
  var g = gcd(n, m);
  var len = n / g * m;
  var sStep = len / n;
  var tStep = len / m;
  var step = sStep / gcd(sStep, tStep) * tStep;
  for (ll i = 0; i < len; i += step) {
    if (s[i / sStep] != t[i / tStep]) {
      cout << -1 << endl;
      return 0;
    }
  }
  cout << len << endl;
}
