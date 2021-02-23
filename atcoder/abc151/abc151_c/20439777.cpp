// detail: https://atcoder.jp/contests/abc151/submissions/20439777
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  cin >> n >> m;
  vector<bool> correct(n + 1);
  vector<int> penas(n + 1);
  for (int i = 0; i < m; i++) {
    int p; string s;
    cin >> p >> s;
    if (s == "AC") correct[p] = true;
    if (s == "WA" && !correct[p]) penas[p]++;
  }
  int pena = 0;
  for (int i = 0; i <= n; i++) if (correct[i]) pena += penas[i];
  cout << count(correct.begin(), correct.end(), true) << " " << pena << endl;
}
