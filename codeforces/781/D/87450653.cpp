// detail: https://codeforces.com/contest/781/submission/87450653
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

bool possibleWithP[64][512][512];
bool possibleWithR[64][512][512];

int main() {
	int n, m;
	cin >> n >> m;
    //vector<vector<vector<bool>>> possibleWithP(62, vector<vector<bool>>(n, vector<bool>(n)));
    //vector<vector<vector<bool>>> possibleWithR(62, vector<vector<bool>>(n, vector<bool>(n)));

    for (int i = 0; i < m; i++)
    {
        int s, t, k;
        cin >> s >> t >> k;
        s--; t--;
        var possible = k == 0 ? possibleWithP : possibleWithR;
        possible[0][s][t] = true;
    }
    for (int i = 1; i < 62; i++)
    {
        vector<bitset<500>> pf(500, bitset<500>());
        vector<bitset<500>> ps(500, bitset<500>());
        vector<bitset<500>> rf(500, bitset<500>());
        vector<bitset<500>> rs(500, bitset<500>());
        for (size_t j = 0; j < n; j++)
        {
            for (size_t k = 0; k < n; k++)
            {
                if (possibleWithP[i - 1][j][k])
                {
                    pf[j].set(k);
                    ps[k].set(j);
                }
                if (possibleWithR[i - 1][j][k])
                {
                    rf[j].set(k);
                    rs[k].set(j);
                }
            }
        }
        
        for (int start = 0; start < n; start++)
        {
            for (int end = 0; end < n; end++)
            {
                var s = pf[start];
                s &= rs[end];
                possibleWithP[i][start][end] = s.any();
            }
        }

        for (int start = 0; start < n; start++)
        {
            for (int end = 0; end < n; end++)
            {
                var s = rf[start];
                s &= ps[end];
                possibleWithR[i][start][end] = s.any();
            }
        }

        for (int start = 0; start < n; start++)
            for (int end = 0; end < n; end++)
                if (possibleWithP[i][start][end] || possibleWithR[i][start][end])
                    goto valid;
        break;
    valid:;
    }
    ll res = 0;
    int next = 0;
    vector<int> candStarts{ 0 };
    for (int i = 62 - 1; i >= 0; i--)
    {
        vector<int> newStarts{};
        var possible = next == 0 ? possibleWithP[i] : possibleWithR[i];
        for (size_t i = 0; i < n; i++)
        {
            for (var&& cand : candStarts) {
                if (possible[cand][i]) {
                    newStarts.push_back(i);
                    break;
                }
            }
        }
        if (newStarts.empty()) {
            continue;
        }
        res |= 1LL << i;
        next ^= 1;
        candStarts = move(newStarts);
    }
    if (1000000000000000000 <= res) res = -1;
    cout << res << endl;
}
