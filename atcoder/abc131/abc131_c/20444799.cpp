// detail: https://atcoder.jp/contests/abc131/submissions/20444799
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

ll solve(ll a, ll c, ll d) {
  var lcm = c / gcd(c, d) * d;
  return a - a / c - a / d + a / lcm;
}

int main() {
  ll a, b, c, d;
  cin >> a >> b >> c >> d;
  cout << solve(b, c, d) - solve(a - 1, c, d) << endl;
}
