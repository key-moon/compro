// detail: https://atcoder.jp/contests/abc064/submissions/20441761
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  vector<int> kind(9);
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    kind[min(8, a / 400)]++;
  }
  int cnt = 8 - count(kind.begin(), kind.end() - 1, 0);
  cout << max(1, cnt) << ' ' << cnt + kind[8] << endl;
}
