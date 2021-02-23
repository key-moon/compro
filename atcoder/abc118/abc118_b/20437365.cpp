// detail: https://atcoder.jp/contests/abc118/submissions/20437365
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
  vector<int> cnt(m + 1);
  for (int i = 0; i < n; i++) {
    int k;
    cin >> k;
    for (int j = 0; j < k; j++) {
      int a;
      cin >> a;
      cnt[a]++;
    }
  }
  cout << count(cnt.begin(), cnt.end(), n) << endl;
}
