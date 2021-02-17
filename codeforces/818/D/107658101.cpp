// detail: https://codeforces.com/contest/818/submission/107658101
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  int n, c;
  cin >> n >> c;
  vector<int> cnts(1000001);
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (cnts[a] < cnts[c]) cnts[a] = INT_MIN;
    cnts[a]++;
  }
  for (int i = 1; i < cnts.size(); i++) {
    if (i == c) continue;
    if (cnts[i] < cnts[c]) continue;
    cout << i << endl;
    return 0;
  }
  cout << -1 << endl;
}
